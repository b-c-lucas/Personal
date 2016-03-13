namespace FHL.Data.Models.NHL
{
    public sealed class Person
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string link { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string primaryNumber { get; set; }
        public string birthDate { get; set; }
        public int currentAge { get; set; }
        public string birthCity { get; set; }
        public string birthStateProvince { get; set; }
        public string birthCountry { get; set; }
        public string height { get; set; }
        public int weight { get; set; }
        public bool active { get; set; }
        public bool rookie { get; set; }
        public string shootsCatches { get; set; }
        public string rosterStatus { get; set; }
        public CurrentTeam currentTeam { get; set; }
        public PrimaryPosition primaryPosition { get; set; }
    }
}