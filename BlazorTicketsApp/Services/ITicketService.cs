using Shared.Models;

namespace BlazorTicketsApp.Services
{
    public interface ITicketService
    {
        public HttpClient Client { get; set; }
        public Task<List<TicketModel>> GetAllTicketsAsync();
        public Task<TicketModel> GetTicketByIdAsync(int id);
        public Task<TicketModel> AddTicketAsync(TicketModel ticket);

    }
}
