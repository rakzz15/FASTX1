using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FastX1.Models
{
    public class BusSchedule
    {
        [Key] 
        public int ScheduleID { get; set; }

        [Required]
        public int RouteID { get; set; } // Foreign key to Route

        [Required]
        public DateTime ScheduleDate { get; set; }

        [Required]
        [RegularExpression("ACTIVE|CANCELLED", ErrorMessage = "Status must be either ACTIVE or CANCELLED")]
        public string Status { get; set; } = "ACTIVE";

        // Navigation property
        public BusRoute Route { get; set; }

        public ICollection<Seat> Seats { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
