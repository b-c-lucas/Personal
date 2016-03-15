using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FHL.Data.DB.FHL.Entities
{
    public class Season : FHLEntityBase
    {
        [Required]
        public DateTime EndDate { get; set; }

        public virtual ICollection<Game> Games { get; set; }
        
        public virtual League League { get; set; }

        [Required]
        public int LeagueId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
    }
}