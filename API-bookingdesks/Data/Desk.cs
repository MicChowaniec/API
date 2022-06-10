using System.ComponentModel.DataAnnotations;

namespace bookingdesks.Data
{
    internal sealed class Desk
    {
        [Key]
        public int DeskId { get; set; }

        [Required]
        [MaxLength(length: 100)]

        public bool IsTaken { get; set; } = false;
        [Required]

        public int RoomId { get; set; }

        public DateTime Date { get; set; }

        
    }   
}
