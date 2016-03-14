using System.Collections.Generic;
using System.Linq;

namespace FHL.Data.Models.NHL
{
    public sealed class Status
    {
        public string abstractGameState { get; set; }
        public string codedGameState { get; set; }
        public string detailedState { get; set; }
        public string statusCode { get; set; }
    }

    public sealed class GameTeam
    {
        public LeagueRecord leagueRecord { get; set; }
        public int score { get; set; }
        public Team team { get; set; }
    }

    public sealed class Teams
    {
        public GameTeam away { get; set; }
        public GameTeam home { get; set; }
    }

    public sealed class Player2
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string link { get; set; }
    }

    public sealed class Player
    {
        public Player2 player { get; set; }
        public string playerType { get; set; }
        public int seasonTotal { get; set; }
    }

    public sealed class Strength
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public sealed class Result
    {
        public string @event { get; set; }
        public string eventCode { get; set; }
        public string eventTypeId { get; set; }
        public string description { get; set; }
        public string secondaryType { get; set; }
        public Strength strength { get; set; }
    }

    public sealed class Goals
    {
        public int away { get; set; }
        public int home { get; set; }
    }

    public sealed class About
    {
        public int eventIdx { get; set; }
        public int eventId { get; set; }
        public int period { get; set; }
        public string periodType { get; set; }
        public string ordinalNum { get; set; }
        public string periodTime { get; set; }
        public string dateTime { get; set; }
        public Goals goals { get; set; }
    }

    public sealed class Coordinates
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public sealed class ScoringPlay
    {
        public List<Player> players { get; set; }
        public Result result { get; set; }
        public About about { get; set; }
        public Coordinates coordinates { get; set; }
        public Team team { get; set; }
    }

    public sealed class Content
    {
        public string link { get; set; }
    }

    public sealed class Game
    {
        public int gamePk { get; set; }
        public string link { get; set; }
        public string gameType { get; set; }
        public string season { get; set; }
        public string gameDate { get; set; }
        public Status status { get; set; }
        public Teams teams { get; set; }
        public List<ScoringPlay> scoringPlays { get; set; }
        public Venue venue { get; set; }
        public Content content { get; set; }
    }

    public sealed class Date
    {
        public string date { get; set; }
        public int totalItems { get; set; }
        public IList<Game> games { get; set; }
    }

    public sealed class ScheduleData
    {
        public IEnumerable<Game> Games
        {
            get
            {
                return this.dates == null 
                    ? null 
                    : this.dates
                        .Where(d => d != null)
                        .SelectMany(d => d.games)
                        .Where(g => g != null);
            }
        }

        public string copyright { get; set; }

        public IList<Date> dates { get; set; }

        public int totalItems { get; set; }

        public int wait { get; set; }
    }
}