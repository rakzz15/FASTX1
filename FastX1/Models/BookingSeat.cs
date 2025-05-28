using System.ComponentModel.DataAnnotations;

namespace FastX1.Models
{
    public class BookingSeat
    {
        [Key]
        public int BookingSeatID { get; set; }

        [Required]
        public int BookingID { get; set; }

        [Required]
        public int SeatID { get; set; }

        public Booking Booking { get; set; }
        public Seat Seat { get; set; }
    }
}
