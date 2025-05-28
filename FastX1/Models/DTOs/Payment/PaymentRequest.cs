namespace FastX1.Models.DTOs.Payment
{
    public class PaymentRequest
    {
        public int BookingID { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
    }
}
