namespace Hackathon_KNU.Models;

public class SuggestionResponse
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public long Viewed { get; set; }
    public long AuthorId { get; set; }
    public User Author { get; set; }
    public DateTime? CreatedAt { get; set; }
    public bool? Liked { get; set; } = null;
    public int Likes { get; set; }
}