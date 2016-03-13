using FHL.Common;
using FHL.Data.DB.NHL;
using FHL.Data.DB.NHL.Entities;
using FHL.Data.DB.NHL.Repositories;
using FHL.Data.Services.NHL;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FHL.Updater
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Database.SetInitializer<NHLContext>(null);

            using (var context = new NHLContext())
            {
                var teamRepository = new TeamRepository(context);
                var playerRepository = new PlayerRepository(context);

                AsyncHelpers.RunSync(() => UpdateTeams(teamRepository));
                AsyncHelpers.RunSync(() => UpdatePlayers(playerRepository, teamRepository));
            }
        }

        private static async Task UpdatePlayers(PlayerRepository playerRepository, TeamRepository teamRepository)
        {
            var playersTask = new PlayerSearcher().GetPlayersAsync();
            var teamsTask = teamRepository.ToListAsync();

            await Task.WhenAll(playersTask, teamsTask);

            var teams = teamsTask.Result;
            
            foreach (var player in playersTask.Result.AsParallel())
            {
                var matchingTeam = teamsTask.Result.FirstOrDefault(t => t.Abbreviation == player.TeamAbbreviation);
                if (matchingTeam == null)
                {
                    Console.WriteLine("No matching team found for " + player.TeamAbbreviation);
                    continue;
                }

                var positionForDb = player.Position.ToString();

                var dbPlayer = await playerRepository.FirstOrDefaultAsync(p => p.Id == player.Id);
                if (dbPlayer == null)
                {
                    playerRepository.Add(
                        new Player
                        {
                            Id = player.Id,
                            FirstName = player.FirstName,
                            LastName = player.LastName,
                            IsActive = player.IsActive,
                            Position = positionForDb,
                            TeamId = matchingTeam.Id,
                            PlayerLink = player.PlayerLink
                        });

                    // need to save changes every time to make sure we're accessing the right data in the loop
                    await playerRepository.SaveChangesAsync();

                    Console.WriteLine("Added player = " + player.FirstName + ' ' + player.LastName);
                }
                else if (dbPlayer.FirstName != player.FirstName
                        || dbPlayer.LastName != player.LastName
                        || dbPlayer.IsActive != player.IsActive
                        || dbPlayer.Position != positionForDb
                        || dbPlayer.TeamId != matchingTeam.Id
                        || dbPlayer.PlayerLink != player.PlayerLink)
                {
                    dbPlayer.FirstName = player.FirstName;
                    dbPlayer.LastName = player.LastName;
                    dbPlayer.IsActive = player.IsActive;
                    dbPlayer.Position = positionForDb;
                    dbPlayer.TeamId = matchingTeam.Id;
                    dbPlayer.PlayerLink = player.PlayerLink;

                    // need to save changes every time to make sure we're accessing the right data in the loop
                    await playerRepository.SaveChangesAsync();

                    Console.WriteLine("Updated player = " + player.FirstName + ' ' + player.LastName);
                }
            }
        }

        private static async Task UpdateTeams(TeamRepository teamRepository)
        {
            var teams = await new StandingsService().GetAllTimeTeamsAsync();

            foreach (var team in teams)
            {
                var dbTeam = await teamRepository.FirstOrDefaultAsync(t => t.Id == team.id);
                if (dbTeam == null)
                {
                    teamRepository.Add(
                        new Team
                        {
                            Id = team.id,
                            Name = team.name,
                            Abbreviation = team.abbreviation
                        });

                    // need to save changes every time to make sure we're accessing the right data in the loop
                    await teamRepository.SaveChangesAsync();

                    Console.WriteLine("Added team = " + team.name);
                }
                else if (dbTeam.Name != team.name 
                    || dbTeam.Abbreviation != team.abbreviation)
                {
                    dbTeam.Name = team.name;
                    dbTeam.Abbreviation = team.abbreviation;

                    // need to save changes every time to make sure we're accessing the right data in the loop
                    await teamRepository.SaveChangesAsync();

                    Console.WriteLine("Updated team = " + team.name);
                }
            }
        }
    }
}