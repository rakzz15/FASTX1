using FastX1.Models;
using FastX1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FastX1.Models.DTOs.BusOperator;

namespace FastX1.Controllers
{
   

    [ApiController]
    [Route("api/[controller]")]
    public class BusOperatorController : ControllerBase
    {
        private readonly IBusOperatorService _operatorService;

        public BusOperatorController(IBusOperatorService operatorService)
        {
            _operatorService = operatorService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterOperator([FromBody] BusOperatorRegisterRequest request)
        {
            try
            {
                var newOperator = new BusOperator
                {
                    Name = request.Name,
                    Email = request.Email,
                    PasswordHash = request.PasswordHash,
                    Phone = request.Phone,
                    Address = request.Address,
                    CreatedAt = DateTime.Now
                };

                var result = await _operatorService.RegisterOperatorAsync(newOperator);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllOperators()
        {
            var operators = await _operatorService.GetAllOperatorsAsync();
            return Ok(operators);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOperatorById(int id)
        {
            var op = await _operatorService.GetOperatorByIdAsync(id);
            if (op == null) return NotFound();
            return Ok(op);
        }
    }

}
