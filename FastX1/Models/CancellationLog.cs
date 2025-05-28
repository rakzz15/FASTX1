using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FastX1.Models
{
    public class CancellationLog
    {
        [Key]
        public int CancelID { get; set; }

        [Required]
        public int BookingID { get; set; }

        [Required]
        public string CancelReason { get; set; }

        public DateTime CancelDate { get; set; } = DateTime.Now;

        [Range(0, double.MaxValue)]
        [Precision(18, 2)]
        public decimal RefundAmount { get; set; }

        public Booking Booking { get; set; }
    }
}
