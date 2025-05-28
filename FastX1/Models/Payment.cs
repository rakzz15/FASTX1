using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FastX1.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        [Required]
        public int BookingID { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.Now;

        [Range(1, double.MaxValue)]
        [Precision(18, 2)]
        public decimal Amount { get; set; }

        [Required]
        public string PaymentMethod { get; set; } = string.Empty;

        [Required, RegularExpression("SUCCESS|FAILED|REFUNDED")]
        public string PaymentStatus { get; set; } = "SUCCESS";

        public Booking? Booking { get; set; }
    }
}
