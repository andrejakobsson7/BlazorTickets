using BlazorTicketsApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlazorTicketsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketTagController : ControllerBase
    {
        private readonly ITicketTagRepository _ticketTagRepository;
        private JsonSerializerOptions _jsonSerializerOptions = new()
        {
            ReferenceHandler = ReferenceHandler.Preserve
        };

        public TicketTagController(ITicketTagRepository ticketTagRepository)
        {
            _ticketTagRepository = ticketTagRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddTicketTagAsync(TicketTag ticketTag)
        {
            TicketTag? newTicketTag = await _ticketTagRepository.AddTicketTagAsync(ticketTag);
            if (newTicketTag == null)
            {
                return BadRequest();
            }
            else
            {
                var ticketJson = JsonSerializer.Serialize(newTicketTag, _jsonSerializerOptions);
                return Ok(ticketJson);
            }
        }
    }
}
