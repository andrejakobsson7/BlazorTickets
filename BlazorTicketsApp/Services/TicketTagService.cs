using Newtonsoft.Json;
using Shared.Models;
using System.Net.Http.Json;

namespace BlazorTicketsApp.Services
{
    public class TicketTagService : ITicketTagService
    {
        public HttpClient Client { get; set; } = new()
        {
            BaseAddress = new Uri("https://localhost:7152/api/TicketTag/")
        };

        public async Task<TicketTag?> AddTicketTagAsync(TicketTag ticketTag)
        {
            var response = await Client.PostAsJsonAsync<TicketTag>(Client.BaseAddress, ticketTag);
            if (response.IsSuccessStatusCode)
            {
                string newTicketTagJson = await response.Content.ReadAsStringAsync();
                TicketTag? newTicketTag = JsonConvert.DeserializeObject<TicketTag>(newTicketTagJson);
                return newTicketTag;
            }
            return null;
        }
    }
}
