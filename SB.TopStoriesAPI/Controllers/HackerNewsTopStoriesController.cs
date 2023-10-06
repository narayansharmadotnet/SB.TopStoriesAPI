using SB.TopStoriesAPI.Core.Interfaces;
using SB.TopStoriesAPI.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace SB.TopStoriesAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class HackerNewsTopStoriesController : ControllerBase
    {
        private readonly ILogger<HackerNewsTopStoriesController> _logger;
        private readonly IHackerNewsService _hackerNewsAggregator;

        public HackerNewsTopStoriesController(ILogger<HackerNewsTopStoriesController> logger,
            IHackerNewsService hackerNewsAggregator)
        {
            _logger = logger;
            _hackerNewsAggregator = hackerNewsAggregator;
        }

        [MapToApiVersion("1.0")]
        [HttpGet(Name = "GetHackerNewsTopStories")]
        public async Task<IReadOnlyCollection<Story>> Get(int topStories, bool disableCache = false)
        {
            _logger.LogInformation("GetHackerNewsTopStories called with {topStories}", topStories);
            var token = HttpContext.RequestAborted;
            return await _hackerNewsAggregator.GetBestStories(topStories, disableCache, token);
        }
    }
}