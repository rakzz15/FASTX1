namespace FastX1.Models.DTOs.User
{
    public class UserLoginRequest
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
