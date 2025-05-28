using System.ComponentModel.DataAnnotations;

namespace FastX1.Models
{
    public class BusOperator
    {
        [Key]
        public int OperatorID { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Phone]
        public string Phone { get; set; }

        public string Address { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<Bus> Buses { get; set; }
    }
}
