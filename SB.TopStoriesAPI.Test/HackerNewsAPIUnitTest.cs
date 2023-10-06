using SB.TopStoriesAPI.Core.Converters;
using SB.TopStoriesAPI.Core.Models;
using Xunit;

namespace SB.TopStoriesAPI.Test
{
    public class HackerNewsAPIUnitTest
    {
        [Fact]
        public void ConvertHackerNewsToStoryTest()
        {
            var hackerNewsStoryDetails = new HackerNewsStoryDetails("author", 1, 1, 1, 1, "title", "type", "url");

            var story = StoryConverter.FromStoryDetails(hackerNewsStoryDetails);
            Assert.NotNull(story);
            Assert.Equal(hackerNewsStoryDetails.Title, story.Title);
            Assert.Equal(hackerNewsStoryDetails.Url, story.Uri);
            Assert.Equal(hackerNewsStoryDetails.By, story.PostedBy);
            Assert.Equal(DateTimeOffset.FromUnixTimeSeconds(hackerNewsStoryDetails.Time).DateTime, story.Time);
            Assert.Equal(hackerNewsStoryDetails.Score, story.Score);
            Assert.Equal(hackerNewsStoryDetails.Descendants, story.CommentCount);
        }
    }
}