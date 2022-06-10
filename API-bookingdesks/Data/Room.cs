using System.ComponentModel.DataAnnotations;

namespace bookingdesks.Data
{
    internal sealed class Room
    {
        [Key]
        public int DeskId { get; set; }

        [Required]
        [MaxLength(length: 100)]

        public string Adress { get; set; } = String.Empty;
        [Required]
        
        public int NumberOfDesks { get; set; } 

        
    }   
}
