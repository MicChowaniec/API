using System.ComponentModel.DataAnnotations;

namespace aspnetserver.Data
{
    internal sealed class Room
    {
        [Key]
        public int RoomId { get; set; }

        [Required]
        [MaxLength(length: 100)]

        public string Title { get; set; } = String.Empty;
        [Required]
        [MaxLength(length: 100000)]
        public string Content { get; set; } = String.Empty;

        
    }   
}
