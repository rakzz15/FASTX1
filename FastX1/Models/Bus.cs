using System.ComponentModel.DataAnnotations;

namespace FastX1.Models
{
    public class Bus
    {
        [Key]
        public int BusID { get; set; }
        [Required]
        public int OperatorID { get; set; }

        [Required, StringLength(100)]
        public string BusName { get; set; }

        [Required, StringLength(20)]
        public string BusNumber { get; set; }

        [Required]
        public string BusType { get; set; }

        [Range(10, 100)]
        public int TotalSeats { get; set; }

        public BusOperator Operator { get; set; }
        public ICollection<BusRoute> Routes { get; set; }
        public ICollection<Amenity> Amenities { get; set; }
    }
}
