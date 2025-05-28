using FastX1.Models;
using FastX1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FastX1.Models.DTOs.Bus;

namespace FastX1.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BusController : ControllerBase
    {
        private readonly IBusService _busService;

        public BusController(IBusService busService)
        {
            _busService = busService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddBus([FromBody] BusCreateRequest request)
        {
            try
            {
                var bus = new Bus
                {
                    OperatorID = request.OperatorID,
                    BusName = request.BusName,
                    BusNumber = request.BusNumber,
                    BusType = request.BusType,
                    TotalSeats = request.TotalSeats
                };

                var addedBus = await _busService.AddBusAsync(bus);
                return Ok(addedBus);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllBuses()
        {
            var buses = await _busService.GetAllBusesAsync();
            return Ok(buses);
        }

        [HttpGet("operator/{operatorId}")]
        public async Task<IActionResult> GetBusesByOperator(int operatorId)
        {
            var buses = await _busService.GetBusesByOperatorAsync(operatorId);
            return Ok(buses);
        }

        [HttpGet("{busId}")]
        public async Task<IActionResult> GetBusById(int busId)
        {
            var bus = await _busService.GetBusByIdAsync(busId);
            if (bus == null) return NotFound();
            return Ok(bus);
        }
    }

}
