namespace FastX1.Models.DTOs.Booking
{
    public class BookingResponse
    {
        public int BookingID { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
