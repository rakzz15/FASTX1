using FastX1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FastX1.Models.DTOs.BusRoute;
using FastX1.Models;

namespace FastX1.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class RouteController : ControllerBase
    {
        private readonly IRouteService _routeService;

        public RouteController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddRoute([FromBody] BusRouteCreateRequest request)
        {
            try
            {
                var route = new BusRoute
                {
                    BusID = request.BusID,
                    Origin = request.Origin,
                    Destination = request.Destination,
                    DepartureTime = request.DepartureTime,
                    ArrivalTime = request.ArrivalTime,
                    Fare = request.Fare
                };

                var addedRoute = await _routeService.AddRouteAsync(route);
                return Ok(addedRoute);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllRoutes()
        {
            var routes = await _routeService.GetAllRoutesAsync();
            return Ok(routes);
        }

        [HttpGet("bus/{busId}")]
        public async Task<IActionResult> GetRoutesByBusId(int busId)
        {
            var routes = await _routeService.GetRoutesByBusIdAsync(busId);
            return Ok(routes);
        }

        [HttpGet("{routeId}")]
        public async Task<IActionResult> GetRouteById(int routeId)
        {
            var route = await _routeService.GetRouteByIdAsync(routeId);
            if (route == null) return NotFound();
            return Ok(route);
        }
    }
}