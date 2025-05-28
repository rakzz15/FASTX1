namespace FastX1.Models.DTOs.Booking
{
    public class BookingRequest
    {
        public int UserID { get; set; }
        public int ScheduleID { get; set; }
        public List<string> SeatNumbers { get; set; }
    }
}
