using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private IFlightService _flightService;
        public FlightsController(IFlightService flightService)
        {
            _flightService = flightService;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _flightService.GetFlightDTOs();
            
            if (result.Success)
            {
                return Ok(result);
            }
            
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = _flightService.Get(id);

            if (result.Success)
            {
                return Ok(result);
            }
            
            return BadRequest(result);
        }

        [HttpDelete]
        public IActionResult Delete(Flight flight)
        {
            var result = _flightService.Delete(flight);

            if (result.Success)
            {
                return Ok(result);
            }
            
            return BadRequest();
        }
        
        [HttpPut]
        public IActionResult Update(Flight flight)
        {
            var result = _flightService.Update(flight);

            if (result.Success)
            {
                return Ok(result);
            }
            
            return BadRequest(result);
        }
    }
}
