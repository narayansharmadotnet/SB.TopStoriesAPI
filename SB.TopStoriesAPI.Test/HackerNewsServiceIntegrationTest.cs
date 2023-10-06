using SB.TopStoriesAPI.Core.Services;
using Xunit;

namespace SB.TopStoriesAPI.Test;

public class HackerNewsServiceIntegrationTest
{
    const string HackerNewsUrl = "https://hacker-news.firebaseio.com";

    [Fact]
    public async Task Get20OfBestStoriesTest()
    {
        var hackerNews = new HackerNewsAPI(HackerNewsUrl);
        var aggregator = new HackerNewsService(hackerNews);

        var bestStories = await aggregator.GetBestStories(20, false, CancellationToken.None);

        Assert.NotNull(bestStories);
        Assert.Equal(20, bestStories.Count);
    }
}