using BlazorTicketsApi.Database;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace BlazorTicketsApi.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        public AppDbContext _context { get; set; }
        public TicketRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<TicketModel>> GetAllTicketsAsync()
        {
            return await _context.Tickets.Include(t => t.Responses).Include(tt => tt.TicketTags).ThenInclude(tt => tt.Tag).OrderBy(t => t.Title).ToListAsync();
        }
        public async Task<TicketModel?> GetTicketByIdAsync(int id)
        {
            return await _context.Tickets.Include(t => t.Responses).Include(tt => tt.TicketTags).ThenInclude(tt => tt.Tag).FirstOrDefaultAsync(t => t.Id == id);
        }
        public async Task<TicketModel> AddTicketAsync(TicketModel ticket)
        {
            try
            {
                foreach (var tag in ticket.TicketTags)
                {
                    List<TagModel> newTicketsTags = await _context.Tags.Where(t => t.Name == tag.Tag.Name).ToListAsync();
                }
                var newTicket = await _context.Tickets.AddAsync(ticket);
                await _context.SaveChangesAsync();
                return newTicket.Entity;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<bool> RemoveTicketAsync(int id)
        {
            TicketModel? ticketToRemove = await GetTicketByIdAsync(id);
            if (ticketToRemove == null)
            {
                return false;
            }
            else
            {
                try
                {
                    _context.Tickets.Remove(ticketToRemove);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public async Task<bool> UpdateTicketAsync(int ticketIdToUpdate, TicketModel updatedTicket)
        {
            {
                TicketModel? ticketToUpdate = await GetTicketByIdAsync(ticketIdToUpdate);
                if (ticketToUpdate == null)
                {
                    return false;
                }
                else
                {
                    try
                    {
                        ticketToUpdate.Title = updatedTicket.Title;
                        ticketToUpdate.Description = updatedTicket.Description;
                        ticketToUpdate.SubmittedBy = updatedTicket.SubmittedBy;
                        ticketToUpdate.IsResolved = updatedTicket.IsResolved;
                        await _context.SaveChangesAsync();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }
        public async Task<bool> UpdateTicketResolvedStatusAsync(int ticketIdToUpdate)
        {
            TicketModel? ticketToUpdate = await GetTicketByIdAsync(ticketIdToUpdate);
            if (ticketToUpdate == null)
            {
                return false;
            }
            else
            {
                try
                {
                    ticketToUpdate.IsResolved = !ticketToUpdate.IsResolved;
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
