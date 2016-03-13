namespace FHL.Data.DB.NHL.Entities
{
    public sealed class Player
    {
        public string FirstName { get; set; }

        public int Id { get; set; }

        public bool IsActive { get; set; }

        public string LastName { get; set; }

        public string PlayerLink { get; set; }

        public string Position { get; set; }

        public string TeamAbbreviation { get; set; }
    }
}