using System.ComponentModel.DataAnnotations;

namespace FHL.Data.DB.FHL.Entities
{
    public sealed class Player : FHLEntityBase
    {
        [Required]
        public int NHLId { get; set; }
    }
}