namespace FHL.Data.Models.NHL
{
    public sealed class LeagueRecord
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ot { get; set; }
        public string type { get; set; }
    }
}