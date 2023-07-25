using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        IPersonService _personService;
        public PersonsController(IPersonService personService) 
        {
            _personService = personService;
        }


        [HttpGet]
        public IActionResult GetAll() 
        { 
            var result = _personService.GetAll();
            return Ok(result);
        }

    }
}
