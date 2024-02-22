using Shared.Models;

namespace BlazorTicketsApp.Services
{
	public interface ITagService
	{
		public HttpClient Client { get; set; }
		public Task<List<TagModel>> GetAllTagsAsync();
	}
}
