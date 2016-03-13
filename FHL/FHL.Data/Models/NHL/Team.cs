namespace FHL.Data.Models.NHL
{ 
    public sealed class Team
    {
        public int id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
        public Venue venue { get; set; }
        public string abbreviation { get; set; }
        public string teamName { get; set; }
        public string locationName { get; set; }
        public string firstYearOfPlay { get; set; }
        public Division2 division { get; set; }
        public Conference2 conference { get; set; }
        public Franchise franchise { get; set; }
        public string officialSiteUrl { get; set; }
        public int franchiseId { get; set; }
        public string shortName { get; set; }
        public bool active { get; set; }
    }
}
