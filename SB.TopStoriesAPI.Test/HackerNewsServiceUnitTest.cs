using SB.TopStoriesAPI.Core.Services;
using SB.TopStoriesAPI.Core.Interfaces;
using SB.TopStoriesAPI.Core.Models;
using Moq;
using Xunit;

namespace SB.TopStoriesAPI.Test;

public class HackerNewsServiceUnitTest
{

    [Fact]
    public async Task GetNumOfBestStories_SequenceTest()
    {
        var hackerNews = new Mock<IHackerNewsAPI>();
        hackerNews.Setup(x => x.GetBestStories(It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        hackerNews.Setup(x => x.GetStoryDetails(1, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new HackerNewsStoryDetails("author", 1, 1, 3, 1, "title", "type", "url"));
        hackerNews.Setup(x => x.GetStoryDetails(2, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new HackerNewsStoryDetails("author", 1, 1, 2, 1, "title", "type", "url") );
        hackerNews.Setup(x => x.GetStoryDetails(3, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new HackerNewsStoryDetails("author", 1, 1, 1, 1, "title", "type", "url"));

        var aggregator = new HackerNewsService(hackerNews.Object);

        var bestStories = await aggregator.GetBestStories(3, false, CancellationToken.None);
        var bestStoriesList = bestStories.ToList();

        Assert.NotNull(bestStories);
        Assert.Equal(3, bestStories.Count);
        Assert.Equal(3, bestStoriesList[0].Score);
        Assert.Equal(2, bestStoriesList[1].Score);
        Assert.Equal(1, bestStoriesList[2].Score);
    }
}