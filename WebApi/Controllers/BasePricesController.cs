using Business.Abstract;
using Core.Utilities.Result;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasePricesController : ControllerBase
    {
        IBasePriceService _basePriceService;
        public BasePricesController(IBasePriceService basePriceService)
        {
            _basePriceService = basePriceService;
        }


        [HttpGet]
        public IActionResult Get(int id) 
        {
            var result = _basePriceService.Get(id);

            if (result.Success)
            {    
                return Ok(result);
            }
            return BadRequest(result);

        }


        [HttpGet]
        public IActionResult GetAll() 
        { 
            var result = _basePriceService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost]
        public IActionResult Add(BasePrice basePrice)
        {
            var result = _basePriceService.Add(basePrice);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _basePriceService.Delete(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPut]
        public IActionResult Update(BasePrice basePrice)
        {
            var result = _basePriceService.Update(basePrice);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
