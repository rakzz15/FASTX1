using FastX1.Models;
using FastX1.Models.DTOs.User;
using FastX1.Services.Interfaces;
using FastX1.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace FastX1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtService _jwtService;

        public UserController(IUserService userService, JwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest request)
        {
            try
            {
                var newUser = new User
                {
                    Name = request.Name,
                    Email = request.Email,
                    PasswordHash = request.PasswordHash,
                    Phone = request.Phone,
                    Role = "USER", // default role
                    CreatedAt = DateTime.Now
                };

                var result = await _userService.RegisterAsync(newUser);

                var response = new UserResponse
                {
                    UserID = result.UserID,
                    Name = result.Name,
                    Email = result.Email,
                    Role = result.Role
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            try
            {
                var user = await _userService.LoginAsync(request.Email, request.PasswordHash);

                var token = _jwtService.GenerateToken(user); // ✅ generate JWT token

                return Ok(new
                {
                    Token = token,
                    User = new UserResponse
                    {
                        UserID = user.UserID,
                        Name = user.Name,
                        Email = user.Email,
                        Role = user.Role
                    }
                });
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound("User not found");

            var response = new UserResponse
            {
                UserID = user.UserID,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role
            };

            return Ok(response);
        }
    }
}
