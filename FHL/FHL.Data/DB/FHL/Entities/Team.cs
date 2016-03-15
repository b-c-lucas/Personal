using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FHL.Data.DB.FHL.Entities
{
    public class Team : FHLEntityBase
    {
        [MaxLength(3)]
        [Required]
        public string Abbreviation { get; set; }

        public virtual Conference Conference { get; set; }

        [Required]
        public int ConferenceId { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}