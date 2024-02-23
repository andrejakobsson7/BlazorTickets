using BlazorTicketsApi.Database;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace BlazorTicketsApi.Repositories
{
    public class ResponseRepository : IResponseRepository
    {
        public AppDbContext _context { get; set; }

        public ResponseRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<ResponseModel>> GetAllResponsesAsync()
        {
            return await _context.Responses.ToListAsync();
        }

        public async Task<ResponseModel?> GetResponseByIdAsync(int id)
        {
            return await _context.Responses.FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task<List<ResponseModel>?> GetAllResponsesByTicketIdAsync(int ticketId)
        {
            return await _context.Responses.Include(r => r.Ticket).Where(r => r.TicketId == ticketId).ToListAsync();
        }
        public async Task<ResponseModel?> AddResponseAsync(ResponseModel response)
        {
            try
            {
                var newResponse = await _context.Responses.AddAsync(response);
                await _context.SaveChangesAsync();
                return newResponse.Entity;
            }
            catch (Exception)
            {
                return null;
            }


        }
        public async Task<bool> RemoveResponseAsync(int id)
        {
            ResponseModel? responseToRemove = await GetResponseByIdAsync(id);
            if (responseToRemove == null)
            {
                return false;
            }
            else
            {
                try
                {
                    _context.Responses.Remove(responseToRemove);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public async Task<bool> UpdateResponseAsync(int responseIdToUpdate, ResponseModel updatedResponse)
        {
            ResponseModel? responseToUpdate = await GetResponseByIdAsync(responseIdToUpdate);
            if (responseToUpdate == null)
            {
                return false;
            }
            else
            {
                try
                {
                    responseToUpdate.Response = updatedResponse.Response;
                    responseToUpdate.SubmittedBy = updatedResponse.SubmittedBy;
                    responseToUpdate.TicketId = updatedResponse.TicketId;
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
