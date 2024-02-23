using BlazorTicketsApi.Database;
using Shared.Models;

namespace BlazorTicketsApi.Repositories
{
    public interface ITicketRepository
    {
        public AppDbContext _context { get; set; }
        public Task<List<TicketModel>> GetAllTicketsAsync();
        public Task<TicketModel?> GetTicketByIdAsync(int id);
        public Task<TicketModel> AddTicketAsync(TicketModel ticket);
        public Task<bool> RemoveTicketAsync(int id);
        public Task<bool> UpdateTicketAsync(int ticketIdToUpdate, TicketModel updatedTicket);
        public Task<bool> UpdateTicketResolvedStatusAsync(int ticketIdToUpdate);
    }
}
