using BlazorTicketsApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlazorTicketsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagRepository _tagRepository;
        private JsonSerializerOptions _jsonSerializerOptions = new()
        {
            ReferenceHandler = ReferenceHandler.Preserve
        };

        public TagController(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTagsAsync()
        {
            List<TagModel> allTags = await _tagRepository.GetAllTagsAsync();
            if (allTags == null)
            {
                return NotFound();
            }
            else
            {
                var tagsJson = JsonSerializer.Serialize(allTags, _jsonSerializerOptions);
                return Ok(tagsJson);
            }
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetTagAsync(int id)
        //{
        //	TagModel? tag = await _tagRepository.GetTagByIdAsync(id);
        //	if (tag == null)
        //	{
        //		return NotFound();
        //	}
        //	else
        //	{
        //		return Ok(tag);
        //	}
        //}

        [HttpGet("{name}")]
        public async Task<IActionResult> GetTagByNameAsync(string name)
        {
            TagModel? tag = await _tagRepository.GetTagByNameAsync(name);
            if (tag == null)
            {
                return BadRequest();
            }
            else
            {
                var tagJson = JsonSerializer.Serialize(tag, _jsonSerializerOptions);
                return Ok(tagJson);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddTagAsync(TagModel tag)
        {
            TagModel newTag = await _tagRepository.AddTagAsync(tag);
            if (newTag == null)
            {
                return BadRequest();
            }
            var tagJson = JsonSerializer.Serialize(newTag, _jsonSerializerOptions);
            return Ok(tagJson);
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
