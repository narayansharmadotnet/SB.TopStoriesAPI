using SB.TopStoriesAPI.Core.Models;

namespace SB.TopStoriesAPI.Core.Interfaces;

public interface IHackerNewsAPI
{
    Task<IReadOnlyCollection<int>> GetBestStories(CancellationToken token);
    Task<HackerNewsStoryDetails?> GetStoryDetails(int storyId, CancellationToken token);

}