using FastX1.Models;
using FastX1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FastX1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusScheduleController : ControllerBase
    {
        private readonly IBusScheduleService _scheduleService;

        public BusScheduleController(IBusScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddSchedule([FromBody] BusSchedule schedule)
        {
            var added = await _scheduleService.AddScheduleAsync(schedule);
            return Ok(added);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _scheduleService.GetAllSchedulesAsync();
            return Ok(list);
        }

        [HttpGet("{routeId}")]
        public async Task<IActionResult> GetByRoute(int routeId)
        {
            var schedules = await _scheduleService.GetByRouteIdAsync(routeId);
            return Ok(schedules);
        }
    }

}
