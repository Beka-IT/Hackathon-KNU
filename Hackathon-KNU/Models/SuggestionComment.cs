namespace Hackathon_KNU.Models;

public class SuggestionComment
{
    public int Id { get; set; }
    public long AuthorId { get; set; }
    public long SuggestionId { get; set; }
    public string Text { get; set; }
    
}