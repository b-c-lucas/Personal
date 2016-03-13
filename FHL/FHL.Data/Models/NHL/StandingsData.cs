using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHL.Data.Models.NHL
{

    public sealed class League
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public sealed class Division
    {
        public int id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
    }

    public sealed class Conference
    {
        public int id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
    }

    public sealed class TimeZone
    {
        public string id { get; set; }
        public int offset { get; set; }
    }

    public sealed class Division2
    {
        public int id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
    }

    public sealed class Conference2
    {
        public int id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
    }

    public sealed class Franchise
    {
        public int franchiseId { get; set; }
        public string teamName { get; set; }
        public string link { get; set; }
    }

    public sealed class Streak
    {
        public string streakType { get; set; }
        public int streakNumber { get; set; }
        public string streakCode { get; set; }
    }

    public sealed class TeamRecord
    {
        public Team team { get; set; }
        public int goalsAgainst { get; set; }
        public int goalsScored { get; set; }
        public int points { get; set; }
        public string divisionRank { get; set; }
        public string conferenceRank { get; set; }
        public string leagueRank { get; set; }
        public string wildCardRank { get; set; }
        public int row { get; set; }
        public int gamesPlayed { get; set; }
        public Streak streak { get; set; }
        public LeagueRecord leagueRecord { get; set; }
        public string lastUpdated { get; set; }
    }

    public sealed class Record
    {
        public string standingsType { get; set; }
        public League league { get; set; }
        public Division division { get; set; }
        public Conference conference { get; set; }
        public List<TeamRecord> teamRecords { get; set; }
    }

    public sealed class StandingsData
    {
        public string copyright { get; set; }
        public List<Record> records { get; set; }
    }
}
