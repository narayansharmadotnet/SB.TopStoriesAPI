using SB.TopStoriesAPI.Core.Interfaces;
using SB.TopStoriesAPI.Core.Models;
using RestSharp;

namespace SB.TopStoriesAPI.Core.Services;

public class HackerNewsAPI : IHackerNewsAPI
{
    private readonly string _serverAddress;

    public HackerNewsAPI(string serverAddress)
    {
        _serverAddress = serverAddress;
    }
    public async Task<IReadOnlyCollection<int>> GetBestStories(CancellationToken token)
    {
        var client = new RestClient(_serverAddress);
        var response = await client.GetJsonAsync<List<int>>("/v0/beststories.json", token);
        return response!;
    }

    public async Task<HackerNewsStoryDetails?> GetStoryDetails(int storyId, CancellationToken token)
    {
        var client = new RestClient(_serverAddress);
        var response = await client.GetJsonAsync<HackerNewsStoryDetails>($"/v0/item/{storyId}.json", token);
        return response;
    }
}