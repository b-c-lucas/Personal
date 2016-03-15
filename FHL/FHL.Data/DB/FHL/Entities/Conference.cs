using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FHL.Data.DB.FHL.Entities
{
    public class Conference : FHLEntityBase
    {
        public virtual League League { get; set; }

        [Required]
        public int LeagueId { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}