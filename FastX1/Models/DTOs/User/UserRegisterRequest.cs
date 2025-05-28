namespace FastX1.Models.DTOs.User
{
    public class UserRegisterRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Phone { get; set; }
    }
}
