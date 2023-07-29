using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirlinesController : ControllerBase
    {
        IAirlineService _airlineService;

        public AirlinesController(IAirlineService airlineService)
        {
            _airlineService = airlineService;
        }



        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = _airlineService.Get(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _airlineService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpPost]
        public IActionResult Add(Airline airline)
        {
            var result = _airlineService.Add(airline);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpPut]
        public IActionResult Update(Airline airline)
        {
            var result = _airlineService.Update(airline);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpDelete]
        public IActionResult Delete(Airline airline)
        {
            var result = _airlineService.Delete(airline);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
