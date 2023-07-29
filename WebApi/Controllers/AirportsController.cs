using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportsController : ControllerBase
    {
        IAirportService _airportService;

        public AirportsController(IAirportService airportService)
        {
            _airportService = airportService;
        }


        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = _airportService.Get(id);

            if (result.Success) 
            { 
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpGet("getall")]
        public IActionResult GetAll() 
        {
            var result = _airportService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpPost]
        public IActionResult Add(Airport airport)
        {
            var result = _airportService.Add(airport);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpPut]
        public IActionResult Update(Airport airport)
        {
            var result = _airportService.Update(airport);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpDelete]
        public IActionResult Delete(Airport airport)
        {
            var result = _airportService.Delete(airport);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

    }
}
