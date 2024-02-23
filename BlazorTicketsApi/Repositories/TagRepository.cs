using BlazorTicketsApi.Database;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace BlazorTicketsApi.Repositories
{
    public class TagRepository : ITagRepository
    {
        public AppDbContext _context { get; set; }
        public TagRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<TagModel>> GetAllTagsAsync()
        {
            return await _context.Tags.ToListAsync();
        }
        public async Task<TagModel?> GetTagByIdAsync(int id)
        {
            return await _context.Tags.FirstOrDefaultAsync(r => r.Id == id);
        }
        public async Task<TagModel?> AddTagAsync(TagModel tag)
        {
            try
            {
                var newTag = await _context.Tags.AddAsync(tag);
                await _context.SaveChangesAsync();
                return newTag.Entity;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<bool> RemoveTagAsync(int id)
        {
            TagModel? tagToRemove = await GetTagByIdAsync(id);
            if (tagToRemove == null)
            {
                return false;
            }
            else
            {
                try
                {
                    _context.Tags.Remove(tagToRemove);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public async Task<bool> UpdateTagAsync(int tagIdToUpdate, TagModel updatedTag)
        {
            TagModel? tagToUpdate = await GetTagByIdAsync(tagIdToUpdate);
            if (tagToUpdate == null)
            {
                return false;
            }
            else
            {
                try
                {
                    tagToUpdate.Name = updatedTag.Name;
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public async Task<TagModel?> GetTagByNameAsync(string name)
        {
            return await _context.Tags.FirstOrDefaultAsync(t => t.Name.ToLower() == name.ToLower());
        }

    }
}
