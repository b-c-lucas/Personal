using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FHL.Data.DB.FHL.Entities
{
    public class Lineup : FHLEntityBase
    {
        [Required]
        public byte Assists { get; set; }

        [NotMapped]
        public IList<GamePlayed> DefencemanGamesPlayed
        {
            get { return null; }
        }

        public virtual GamePlayed Defenceman1GamePlayed { get; set; }

        public int? Defenceman1GamePlayedId { get; set; }

        public virtual GamePlayed Defenceman2GamePlayed { get; set; }

        public int? Defenceman2GamePlayedId { get; set; }

        public virtual GamePlayed Defenceman3GamePlayed { get; set; }

        public int? Defenceman3GamePlayedId { get; set; }

        public virtual GamePlayed Defenceman4GamePlayed { get; set; }

        public int? Defenceman4GamePlayedId { get; set; }

        [NotMapped]
        public IList<GamePlayed> ForwardGamesPlayed
        {
            get { return null; }
        }

        public virtual GamePlayed Forward1GamePlayed { get; set; }

        public int? Forward1GamePlayedId { get; set; }

        public virtual GamePlayed Forward2GamePlayed { get; set; }

        public int? Forward2GamePlayedId { get; set; }

        public virtual GamePlayed Forward3GamePlayed { get; set; }

        public int? Forward3GamePlayedId { get; set; }

        public virtual GamePlayed Forward4GamePlayed { get; set; }

        public int? Forward4GamePlayedId { get; set; }

        public virtual GamePlayed Forward5GamePlayed { get; set; }

        public int? Forward5GamePlayedId { get; set; }

        public virtual GamePlayed Forward6GamePlayed { get; set; }

        public int? Forward6GamePlayedId { get; set; }

        public int? GoalieId { get; set; }

        [Required]
        public byte Score { get; set; }

        public virtual Team Team { get; set; }

        [Required]
        public int TeamId { get; set; }
    }
}