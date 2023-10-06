namespace SB.TopStoriesAPI.Core.Models;

public record Story(string? Title, string? Uri, string? PostedBy, DateTime Time, int Score, int CommentCount);