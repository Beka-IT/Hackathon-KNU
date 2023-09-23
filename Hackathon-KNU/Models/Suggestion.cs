namespace Hackathon_KNU.Models;

public class Suggestion
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public long Viewed { get; set; }
    public long AuthorId { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    public IList<SuggestionUserLikes>? SuggestionUserLikes { get; set; }
}