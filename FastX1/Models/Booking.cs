using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FastX1.Models
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public int ScheduleID { get; set; }

        public DateTime BookingDate { get; set; } = DateTime.Now;

        [Range(1, double.MaxValue)]
        [Precision(18, 2)]
        public decimal TotalAmount { get; set; }

        [Required, RegularExpression("CONFIRMED|CANCELLED")]
        public string Status { get; set; } = "CONFIRMED";

        public User User { get; set; }
        public BusSchedule Schedule { get; set; }
        public Payment Payment { get; set; }
        public CancellationLog CancellationLog { get; set; }
        public ICollection<BookingSeat> BookingSeats { get; set; }
    }
}
