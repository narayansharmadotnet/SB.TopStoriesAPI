namespace SB.TopStoriesAPI.Core.Models;

public record HackerNewsStoryDetails(String? By, int Descendants, int Id, int Score, int Time, string? Title, string? Type, string? Url);