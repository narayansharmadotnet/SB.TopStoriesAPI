using SB.TopStoriesAPI.Core.Models;

namespace SB.TopStoriesAPI.Core.Interfaces;

public interface IHackerNewsService
{
    public Task<IReadOnlyCollection<Story>> GetBestStories(int top, bool disableCache, CancellationToken token);
}