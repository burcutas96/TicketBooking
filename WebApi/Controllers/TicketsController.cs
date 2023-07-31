using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost]
        public IActionResult Add(Ticket ticket)
        {
            var result = _ticketService.Add(ticket);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _ticketService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        
        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = _ticketService.Get(id);

            if (result.Success)
            {
                return Ok(result);
            }
            
            return BadRequest(result);
        }
        
        [HttpDelete]
        public IActionResult Delete(Ticket ticket)
        {
            var result = _ticketService.Delete(ticket);

            if (result.Success)
            {
                return Ok(result);
            }
            
            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update(Ticket ticket)
        {
            var result = _ticketService.Update(ticket);

            if (result.Success)
            {
                return Ok(result);
            }
            
            return BadRequest(result);
        }

    }
}