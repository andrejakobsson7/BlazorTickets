using Newtonsoft.Json;
using Shared.Models;
using System.Net.Http.Json;

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
            var apiResponse = await Client.GetAsync(Client.BaseAddress);
            if (apiResponse.IsSuccessStatusCode)
            {
                string jsonResponse = await apiResponse.Content.ReadAsStringAsync();
                List<ResponseModel>? allResponses = JsonConvert.DeserializeObject<List<ResponseModel>>(jsonResponse);
                if (allResponses != null)
                {
                    return allResponses;
                }
                throw new JsonException();
            }
            throw new HttpRequestException();
        }

        public async Task<List<ResponseModel>> GetAllResponsesByTicketIdAsync(int ticketId)
        {
            var apiResponse = await Client.GetAsync($"{ticketId}");
            if (apiResponse.IsSuccessStatusCode)
            {
                string jsonResponse = await apiResponse.Content.ReadAsStringAsync();
                List<ResponseModel>? allResponses = JsonConvert.DeserializeObject<List<ResponseModel>>(jsonResponse);
                if (allResponses != null)
                {
                    return allResponses;
                }
                throw new JsonException();
            }
            throw new HttpRequestException();
        }

        public async Task<List<ResponseModel>?> AddResponseAsync(ResponseModel response)
        {
            var apiResponse = await Client.PostAsJsonAsync<ResponseModel>(Client.BaseAddress, response);
            if (apiResponse.IsSuccessStatusCode)
            {
                string newResponseJson = await apiResponse.Content.ReadAsStringAsync();
                List<ResponseModel>? allResponses = JsonConvert.DeserializeObject<List<ResponseModel>>(newResponseJson);
                return allResponses;
            }
            return null;
        }
    }
}
