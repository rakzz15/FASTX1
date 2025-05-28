using System.ComponentModel.DataAnnotations;

namespace FastX1.Models
{
    public class Amenity
    {
        [Key]
        public int AmenityID { get; set; }

        [Required]
        public int BusID { get; set; }

        [Required]
        public string AmenityType { get; set; }

        public Bus Bus { get; set; }
    }
}
