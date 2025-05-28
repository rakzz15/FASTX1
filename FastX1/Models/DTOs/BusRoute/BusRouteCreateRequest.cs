namespace FastX1.Models.DTOs.BusRoute
{
    public class BusRouteCreateRequest
    {
        public int BusID { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public decimal Fare { get; set; }
    }
}
