﻿using Newtonsoft.Json;
using Shared.Models;

namespace BlazorTicketsApp.Services
{
	public class TagService : ITagService
	{
		public HttpClient Client { get; set; } = new()
		{
			BaseAddress = new Uri("https://localhost:7152/api/tag/")
		};


		public async Task<List<TagModel>> GetAllTagsAsync()
		{
			var response = await Client.GetAsync(Client.BaseAddress);
			if (response.IsSuccessStatusCode)
			{
				string jsonResponse = await response.Content.ReadAsStringAsync();
				List<TagModel>? allTags = JsonConvert.DeserializeObject<List<TagModel>>(jsonResponse);
				if (allTags != null)
				{
					return allTags;
				}
				throw new JsonException();
			}
			throw new HttpRequestException();
		}
	}
}
