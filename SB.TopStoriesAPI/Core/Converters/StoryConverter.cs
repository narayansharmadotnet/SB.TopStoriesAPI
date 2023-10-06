using SB.TopStoriesAPI.Core.Models;

namespace SB.TopStoriesAPI.Core.Converters
{
    public class StoryConverter
    {
        public static Story FromStoryDetails(HackerNewsStoryDetails hackerNewsStoryDetails)
        {
            return new Story(
                hackerNewsStoryDetails.Title,
                hackerNewsStoryDetails.Url,
                hackerNewsStoryDetails.By,
                DateTimeOffset.FromUnixTimeSeconds(hackerNewsStoryDetails.Time).DateTime,
                hackerNewsStoryDetails.Score,
                hackerNewsStoryDetails.Descendants
            );
        }
    }
}
