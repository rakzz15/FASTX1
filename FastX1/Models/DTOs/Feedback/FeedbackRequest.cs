namespace FastX1.Models.DTOs.Feedback
{
    public class FeedbackRequest
    {
        public int UserID { get; set; }
        public int RouteID { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
    }
}
