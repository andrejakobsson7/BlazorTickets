using BlazorTicketsApi.Database;
using Shared.Models;

namespace BlazorTicketsApi.Repositories
{
    public class TicketTagRepository : ITicketTagRepository
    {
        public AppDbContext _context { get; set; }

        public TicketTagRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TicketTag?> AddTicketTagAsync(TicketTag ticketTag)
        {
            try
            {
                var newTicketTag = await _context.TicketTags.AddAsync(ticketTag);
                await _context.SaveChangesAsync();
                return newTicketTag.Entity;
            }
            catch (Exception)
            {
                return null;
            }
        }


    }
}
