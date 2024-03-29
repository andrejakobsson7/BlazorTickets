﻿using Newtonsoft.Json;
using Shared.Models;
using System.Net.Http.Json;

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

        public async Task<TagModel?> AddTagAsync(TagModel newTag)
        {
            var apiResponse = await Client.PostAsJsonAsync<TagModel>(Client.BaseAddress, newTag);
            if (apiResponse.IsSuccessStatusCode)
            {
                string newTagJson = await apiResponse.Content.ReadAsStringAsync();
                TagModel? addedTag = JsonConvert.DeserializeObject<TagModel>(newTagJson);
                return addedTag;
            }
            return null;
        }

        public async Task<TagModel?> GetTagByNameAsync(string name)
        {
            var apiResponse = await Client.GetAsync(name);
            if (apiResponse.IsSuccessStatusCode)
            {
                string tagJson = await apiResponse.Content.ReadAsStringAsync();
                TagModel? tag = JsonConvert.DeserializeObject<TagModel>(tagJson);
                return tag;
            }
            return null;
        }

    }
}
