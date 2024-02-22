using Shared.Models;

namespace BlazorTicketsApp.Services
{
	public interface ITicketService
	{
		public HttpClient Client { get; set; }
		public Task<List<TicketModel>> GetAllTicketsAsync();
	}
}
