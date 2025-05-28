using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FastX1.Models
{
    public class BusRoute
    {
        [Key]
        public int RouteID { get; set; }


        [Required]
        public int BusID { get; set; }

        [Required]
        public string Origin { get; set; }

        [Required]
        public string Destination { get; set; }

        [Required]
        public TimeSpan DepartureTime { get; set; }

        [Required]
        public TimeSpan ArrivalTime { get; set; }

        [Range(50, 5000)]
        [Precision(18, 2)]
        public decimal Fare { get; set; }

        public Bus Bus { get; set; }
        public ICollection<BusSchedule> BusSchedules { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
    }
}
