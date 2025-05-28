using System.ComponentModel.DataAnnotations;

namespace FastX1.Models
{
    public class Seat
    {
        [Key]
        public int SeatID { get; set; }

        [Required]
        public int ScheduleID { get; set; }

        [Required]
        public string SeatNumber { get; set; }

        public bool IsBooked { get; set; }

        public BusSchedule Schedule { get; set; }
        public ICollection<BookingSeat> BookingSeats { get; set; }
    }
}
