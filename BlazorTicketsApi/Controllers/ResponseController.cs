using BlazorTicketsApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlazorTicketsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseController : ControllerBase
    {
        private readonly IResponseRepository _responseRepository;
        private JsonSerializerOptions _jsonSerializerOptions = new()
        {
            ReferenceHandler = ReferenceHandler.Preserve
        };

        public ResponseController(IResponseRepository responseRepository)
        {
            _responseRepository = responseRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllResponsesAsync()
        {
            List<ResponseModel> allResponses = await _responseRepository.GetAllResponsesAsync();
            if (allResponses == null)
            {
                return NotFound();
            }
            else
            {
                var responsesJson = JsonSerializer.Serialize(allResponses, _jsonSerializerOptions);
                return Ok(responsesJson);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetResponsesByTicketIdAsync(int id)
        {
            List<ResponseModel>? allResponses = await _responseRepository.GetAllResponsesByTicketIdAsync(id);
            if (allResponses == null)
            {
                return NotFound();
            }
            else
            {
                var responsesJson = JsonSerializer.Serialize(allResponses, _jsonSerializerOptions);
                return Ok(responsesJson);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddResponseAsync(ResponseModel response)
        {
            ResponseModel? newResponse = await _responseRepository.AddResponseAsync(response);
            if (newResponse == null)
            {
                return BadRequest();
            }
            var responsesJson = JsonSerializer.Serialize(newResponse, _jsonSerializerOptions);
            return Ok(responsesJson);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveResponseAsync(int id)
        {
            bool isSuccessfullyRemoved = await _responseRepository.RemoveResponseAsync(id);
            if (isSuccessfullyRemoved)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateResponseAsync(int responseIdToUpdate, ResponseModel updatedResponse)
        {
            bool isSuccessfullyUpdated = await _responseRepository.UpdateResponseAsync(responseIdToUpdate, updatedResponse);
            if (isSuccessfullyUpdated)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
