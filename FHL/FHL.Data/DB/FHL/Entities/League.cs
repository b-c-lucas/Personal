using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FHL.Data.DB.FHL.Entities
{
    public class League : FHLEntityBase
    {
        public virtual ICollection<Conference> Conferences { get; set; }

        [Required]
        public byte FarmSize { get; set; }

        [Required]
        public byte MaxNumberOfTeams { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [Required]
        public byte NumberOfPlayoffRounds { get; set; }

        public DateTime? RosterFreezeDateTime { get; set; }

        [Required]
        public byte RosterSize { get; set; }

        [Required]
        public byte SalaryCap { get; set; }

        [NotMapped]
        public IEnumerable<Team> Teams
        {
            get { return this.Conferences.SelectMany(c => c.Teams); }
        }

        public DateTime? TradeDeadlineDateTime { get; set; }
    }
}