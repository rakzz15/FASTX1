using System.ComponentModel.DataAnnotations;

namespace FastX1.Models
{
    public class User
    {
        [Key]

        public int UserID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Required]
        [RegularExpression("USER|ADMIN")]
        public string Role { get; set; } = "USER";

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
    }
}
