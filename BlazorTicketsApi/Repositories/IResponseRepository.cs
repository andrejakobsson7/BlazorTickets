using BlazorTicketsApi.Database;
using Shared.Models;

namespace BlazorTicketsApi.Repositories
{
	public interface IResponseRepository
	{
		public AppDbContext _context { get; set; }
		public Task<List<ResponseModel>> GetAllResponsesAsync();
		public Task<ResponseModel?> GetResponseByIdAsync(int id);
		public Task<bool> AddResponseAsync(ResponseModel response);
		public Task<bool> RemoveResponseAsync(int id);
		public Task<bool> UpdateResponseAsync(int responseIdToUpdate, ResponseModel updatedResponse);

	}
}
