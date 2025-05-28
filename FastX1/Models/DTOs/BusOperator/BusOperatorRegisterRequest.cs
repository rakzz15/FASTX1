namespace FastX1.Models.DTOs.BusOperator
{
    public class BusOperatorRegisterRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
