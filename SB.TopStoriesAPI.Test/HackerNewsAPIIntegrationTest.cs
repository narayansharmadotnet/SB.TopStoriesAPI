using SB.TopStoriesAPI.Core.Services;
using Xunit;

namespace SB.TopStoriesAPI.Test;

public class HackerNewsAPIIntegrationTest
{
    private const string HackerNewsUrl = "https://hacker-news.firebaseio.com";

    [Fact]
    public async Task GetBestStoriesTest()
    {
        var hackerNews = new HackerNewsAPI(HackerNewsUrl);
        
        var bestStories = await hackerNews.GetBestStories(CancellationToken.None);
        
        Assert.NotNull(bestStories);
        Assert.NotEmpty(bestStories);
    }

    [Fact]
    public async Task GetStoryDetailsTest()
    {
        var hackerNews = new HackerNewsAPI(HackerNewsUrl);
        
        var storyDetails = await hackerNews.GetStoryDetails(8863, CancellationToken.None);
        
        Assert.NotNull(storyDetails);
        Assert.Equal(8863, storyDetails!.Id);
    }
}