using Shared.Models;

namespace BlazorTicketsApp.Services
{
	public interface IResponseService
	{
		public HttpClient Client { get; set; }
		public Task<List<ResponseModel>> GetAllResponsesAsync();
	}
}
