using BlazorTicketsApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace BlazorTicketsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTicketsAsync()
        {
            List<TicketModel> allTickets = await _ticketRepository.GetAllTicketsAsync();
            if (allTickets == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(allTickets);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTicketAsync(int id)
        {
            TicketModel? ticket = await _ticketRepository.GetTicketByIdAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ticket);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddTicketAsync(TicketModel ticket)
        {
            bool isSuccesfullyAdded = await _ticketRepository.AddTicketAsync(ticket);
            if (isSuccesfullyAdded)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTicketAsync(int id)
        {
            bool isSuccessfullyRemoved = await _ticketRepository.RemoveTicketAsync(id);
            if (isSuccessfullyRemoved)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTicketAsync(int ticketIdToUpdate, TicketModel updatedTicket)
        {
            bool isSuccessfullyUpdated = await _ticketRepository.UpdateTicketAsync(ticketIdToUpdate, updatedTicket);
            if (isSuccessfullyUpdated)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicketResolvedStatusAsync(int id)
        {
            bool isSuccessfullyUpdated = await _ticketRepository.UpdateTicketResolvedStatusAsync(id);
            if (isSuccessfullyUpdated)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
