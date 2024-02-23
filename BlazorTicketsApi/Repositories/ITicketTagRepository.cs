using BlazorTicketsApi.Database;
using Shared.Models;

namespace BlazorTicketsApi.Repositories
{
    public interface ITicketTagRepository
    {
        public AppDbContext _context { get; set; }

        public Task<TicketTag?> AddTicketTagAsync(TicketTag ticketTag);
    }
}
