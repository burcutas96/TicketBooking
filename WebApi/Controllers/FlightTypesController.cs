using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FlightTypesController : ControllerBase
    {
        IFlightTypeService _flightTypeService;

        public FlightTypesController(IFlightTypeService flightTypeService)
        {
            _flightTypeService = flightTypeService;
        }



        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = _flightTypeService.Get(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _flightTypeService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpPost]
        public IActionResult Add(FlightType flightType)
        {
            var result = _flightTypeService.Add(flightType);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpPut]
        public IActionResult Update(FlightType flightType)
        {
            var result = _flightTypeService.Update(flightType);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpDelete]
        public IActionResult Delete(FlightType flightType)
        {
            var result = _flightTypeService.Delete(flightType);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
