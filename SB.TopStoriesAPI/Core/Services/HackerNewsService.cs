using SB.TopStoriesAPI.Core.Converters;
using SB.TopStoriesAPI.Core.Interfaces;
using SB.TopStoriesAPI.Core.Models;
using System.Collections.Concurrent;

namespace SB.TopStoriesAPI.Core.Services;

public class HackerNewsService:IHackerNewsService
{
    private readonly IHackerNewsAPI _hackerNews;
    private readonly ConcurrentDictionary<int, HackerNewsStoryDetails?> _storyCache;

    public HackerNewsService(IHackerNewsAPI hackerNews)
    {
        _hackerNews = hackerNews;
        _storyCache = new ConcurrentDictionary<int, HackerNewsStoryDetails?>();
    }

    public async Task<IReadOnlyCollection<Story>> GetBestStories(int top, bool disableCache, CancellationToken token)
    {
        var bestStoriesCollection = new List<Story>();
        var bestStories = await _hackerNews.GetBestStories(token);
        foreach (var storyId in bestStories.Take(top))
        {
            var storyDetails = await GetStoryFromCache(storyId, disableCache, token);
            bestStoriesCollection.Add(StoryConverter.FromStoryDetails(storyDetails!));
        }

        return bestStoriesCollection.OrderByDescending(t=>t.Score).ToList();
    }

    private async Task<HackerNewsStoryDetails?> GetStoryFromCache(int storyId, bool disableCache, CancellationToken token)
    {
        HackerNewsStoryDetails? story;
        if (disableCache == true)
        {
            story = await _hackerNews.GetStoryDetails(storyId, token);
        }
        else
        {
            _storyCache.TryGetValue(storyId, out story);

            if (story == null)
            {
                story = await _hackerNews.GetStoryDetails(storyId, token);
                _storyCache.TryAdd(storyId, story);
            }
        }

        return story;
    }
}