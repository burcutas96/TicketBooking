using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PriceDetailsController : ControllerBase
    {
        IPriceDetailService _priceDetailService;

        public PriceDetailsController(IPriceDetailService priceDetailService)
        {
            _priceDetailService = priceDetailService;
        }


        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = _priceDetailService.Get(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _priceDetailService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost]
        public IActionResult Add(PriceDetail priceDetail)
        {
            var result = _priceDetailService.Add(priceDetail);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _priceDetailService.Delete(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPut]
        public IActionResult Update(PriceDetail priceDetail)
        {
            var result = _priceDetailService.Update(priceDetail);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

   
