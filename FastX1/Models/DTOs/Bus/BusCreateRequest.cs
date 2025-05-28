namespace FastX1.Models.DTOs.Bus
{
    public class BusCreateRequest
    {
        public int OperatorID { get; set; }
        public string BusName { get; set; }
        public string BusNumber { get; set; }
        public string BusType { get; set; }
        public int TotalSeats { get; set; }
    }
}
