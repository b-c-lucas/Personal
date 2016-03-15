using System;
using System.ComponentModel.DataAnnotations;

namespace FHL.Data.DB.NHL.Entities
{
    public sealed class Player : NHLEntityBase
    {
        [MaxLength(100)]
        [Required]
        public string FirstName { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [MaxLength(100)]
        [Required]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string PlayerLink { get; set; }

        [MaxLength(1)]
        [Required]
        public string Position { get; set; }

        [Required]
        public Team Team { get; private set; }

        [Required]
        public int TeamId { get; set; }

        public char GetPositionAsChar()
        {
            return Convert.ToChar(this.Position);
        }
    }
}