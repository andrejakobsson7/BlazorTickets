using Newtonsoft.Json;
using Shared.Models;

namespace BlazorTicketsApp.Services
{
	public class ResponseService : IResponseService
	{
		public HttpClient Client { get; set; } = new()
		{
			BaseAddress = new Uri("https://localhost:7152/api/response/")
		};

		public async Task<List<ResponseModel>> GetAllResponsesAsync()
		{
			var response = await Client.GetAsync(Client.BaseAddress);
			if (response.IsSuccessStatusCode)
			{
				string jsonResponse = await response.Content.ReadAsStringAsync();
				List<ResponseModel>? allResponses = JsonConvert.DeserializeObject<List<ResponseModel>>(jsonResponse);
				if (allResponses != null)
				{
					return allResponses;
				}
				throw new JsonException();
			}
			throw new HttpRequestException();
		}
	}
}
