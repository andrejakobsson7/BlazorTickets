using BlazorTicketsApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace BlazorTicketsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseController : ControllerBase
    {
        private readonly IResponseRepository _responseRepository;

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
                return Ok(allResponses);
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
                return Ok(allResponses);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddResponseAsync(ResponseModel response)
        {
            bool isSuccesfullyAdded = await _responseRepository.AddResponseAsync(response);
            if (isSuccesfullyAdded)
            {
                return Ok();
            }
            return BadRequest();
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
