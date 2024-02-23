using Newtonsoft.Json;
using Shared.Models;
using System.Net.Http.Json;


namespace BlazorTicketsApp.Services
{
    public class TicketService : ITicketService
    {
        public HttpClient Client { get; set; } = new()
        {
            BaseAddress = new Uri("https://localhost:7152/api/ticket/")
        };

        public async Task<List<TicketModel>> GetAllTicketsAsync()
        {
            var response = await Client.GetAsync(Client.BaseAddress);
            if (response.IsSuccessStatusCode)
            {
                string jsonTickets = await response.Content.ReadAsStringAsync();
                List<TicketModel>? allTickets = JsonConvert.DeserializeObject<List<TicketModel>>(jsonTickets);
                if (allTickets != null)
                {
                    return allTickets;
                }
                throw new JsonException();
            }
            throw new HttpRequestException();
        }

        public async Task<TicketModel> GetTicketByIdAsync(int id)
        {

            var response = await Client.GetAsync($"{id}");
            if (response.IsSuccessStatusCode)
            {
                string jsonTicket = await response.Content.ReadAsStringAsync();
                TicketModel? ticket = JsonConvert.DeserializeObject<TicketModel>(jsonTicket);
                if (ticket != null)
                {
                    return ticket;
                }
                throw new JsonException();
            }
            throw new HttpRequestException();
        }

        public async Task<TicketModel?> AddTicketAsync(TicketModel ticket)
        {
            var response = await Client.PostAsJsonAsync<TicketModel>(Client.BaseAddress, ticket);
            if (response.IsSuccessStatusCode)
            {
                string newTicketJson = await response.Content.ReadAsStringAsync();
                TicketModel? newTicket = JsonConvert.DeserializeObject<TicketModel>(newTicketJson);
                return newTicket;
            }
            return null;
        }

    }
}
