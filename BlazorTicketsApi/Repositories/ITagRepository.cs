using BlazorTicketsApi.Database;
using Shared.Models;

namespace BlazorTicketsApi.Repositories
{
    public interface ITagRepository
    {
        public AppDbContext _context { get; set; }
        public Task<List<TagModel>> GetAllTagsAsync();
        public Task<TagModel?> GetTagByIdAsync(int id);
        public Task<TagModel?> AddTagAsync(TagModel tag);
        public Task<bool> RemoveTagAsync(int id);
        public Task<bool> UpdateTagAsync(int tagIdToUpdate, TagModel tagToUpdate);
        public Task<TagModel> GetTagByNameAsync(string name);

    }
}
