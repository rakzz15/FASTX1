using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastX1.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public int RouteID { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        public string Comments { get; set; }

        public DateTime SubmittedAt { get; set; } = DateTime.Now;
        [ForeignKey("UserID")]
        public User User { get; set; }

        [ForeignKey("RouteID")]
        public BusRoute BusRoute { get; set; }
    }
}
