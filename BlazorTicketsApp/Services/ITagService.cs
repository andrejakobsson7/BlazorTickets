using Shared.Models;

namespace BlazorTicketsApp.Services
{
    public interface ITagService
    {
        public HttpClient Client { get; set; }
        public Task<List<TagModel>> GetAllTagsAsync();
        public Task<TagModel?> GetTagByNameAsync(string name);
        public Task<TagModel?> AddTagAsync(TagModel tag);
    }
}
