using BlazorTicketsApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace BlazorTicketsApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TagController : ControllerBase
	{
		private readonly ITagRepository _tagRepository;

		public TagController(ITagRepository tagRepository)
		{
			_tagRepository = tagRepository;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllTagsAsync()
		{
			List<TagModel> allResponses = await _tagRepository.GetAllTagsAsync();
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
		public async Task<IActionResult> GetTagAsync(int id)
		{
			TagModel? tag = await _tagRepository.GetTagByIdAsync(id);
			if (tag == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(tag);
			}
		}

		[HttpPost]
		public async Task<IActionResult> AddTagAsync(TagModel tag)
		{
			bool isSuccesfullyAdded = await _tagRepository.AddTagAsync(tag);
			if (isSuccesfullyAdded)
			{
				return Ok();
			}
			return BadRequest();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveTagAsync(int id)
		{
			bool isSuccessfullyRemoved = await _tagRepository.RemoveTagAsync(id);
			if (isSuccessfullyRemoved)
			{
				return Ok();
			}
			return BadRequest();
		}

		[HttpPut]
		public async Task<IActionResult> UpdateTagAsync(int tagIdToUpdate, TagModel updatedTag)
		{
			bool isSuccessfullyUpdated = await _tagRepository.UpdateTagAsync(tagIdToUpdate, updatedTag);
			if (isSuccessfullyUpdated)
			{
				return Ok();
			}
			return BadRequest();
		}
	}
}
