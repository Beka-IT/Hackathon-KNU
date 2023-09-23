namespace Hackathon_KNU.Models;

public class SuggestionUserLikes
{
    public long UserId { get; set; }
    public long SuggestionId { get; set; }
    public User User { get; set; } = null!;
    public Suggestion Suggestion { get; set; } = null!;
}