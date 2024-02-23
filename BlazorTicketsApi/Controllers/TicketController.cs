using BlazorTicketsApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlazorTicketsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;
        private JsonSerializerOptions _jsonSerializerOptions = new()
        {
            ReferenceHandler = ReferenceHandler.Preserve
        };

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
                var ticketsJson = JsonSerializer.Serialize(allTickets, _jsonSerializerOptions);
                return Ok(ticketsJson);
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
                var ticketJson = JsonSerializer.Serialize(ticket, _jsonSerializerOptions);
                return Ok(ticketJson);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddTicketAsync(TicketModel ticket)
        {
            TicketModel newTicket = await _ticketRepository.AddTicketAsync(ticket);
            if (newTicket == null)
            {
                return BadRequest();
            }
            else
            {
                var ticketJson = JsonSerializer.Serialize(newTicket, _jsonSerializerOptions);
                return Ok(ticketJson);
            }
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
