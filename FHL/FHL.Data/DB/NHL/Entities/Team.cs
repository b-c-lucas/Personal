using System.ComponentModel.DataAnnotations;

namespace FHL.Data.DB.NHL.Entities
{
    public sealed class Team : NHLEntityBase
    {
        [MaxLength(3)]
        [Required]
        public string Abbreviation { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
    }
}