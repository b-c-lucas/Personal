using System;
using System.ComponentModel.DataAnnotations;

namespace FHL.Data.DB.FHL.Entities
{
    public class Game : FHLEntityBase
    {
        public virtual Lineup AwayLineup { get; set; }

        [Required]
        public int AwayLineupId { get; set; }

        [Required]
        public byte GameNumber { get; set; }

        [Required]
        public GameType GameType { get; set; }

        public virtual Lineup HomeLineup { get; set; }

        [Required]
        public int HomeLineupId { get; set; }

        public virtual Season Season { get; set; }

        [Required]
        public int SeasonId { get; set; }

        [Required]
        public DateTime StartDateTime { get; set; }
    }
}