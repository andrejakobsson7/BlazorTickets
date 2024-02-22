using Newtonsoft.Json;
using Shared.Models;


namespace BlazorTicketsApp.Services
{
	public class TicketService : ITicketService
	{
		public HttpClient Client { get; set; } = new()
		{
			BaseAddress = new Uri("https://localhost:7152/api/ticket")
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

	}
}
