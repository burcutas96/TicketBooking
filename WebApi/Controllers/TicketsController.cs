using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;
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

            if (result.success)
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
            var result = _flightService.Delete(ticket);

            if (result.Success)
            {
                return Ok(result);
            }
            
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Update(Ticket ticket)
        {
            var result = _flightService.Update(ticket);

            if (result.Success)
            {
                return Ok(result);
            }
            
            return BadRequest(result);
        }

    }
}