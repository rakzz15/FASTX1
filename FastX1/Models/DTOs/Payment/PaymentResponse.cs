namespace FastX1.Models.DTOs.Payment
{
    public class PaymentResponse
    {
        public int PaymentID { get; set; }
        public int BookingID { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
    }
}
