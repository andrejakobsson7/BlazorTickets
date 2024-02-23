using Shared.Models;

namespace BlazorTicketsApp.Services
{
    public interface ITicketTagService
    {
        public HttpClient Client { get; set; }
        public Task<TicketTag?> AddTicketTagAsync(TicketTag newTicketTag);
    }
}
