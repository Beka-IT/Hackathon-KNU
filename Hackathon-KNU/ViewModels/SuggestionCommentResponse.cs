using Hackathon_KNU.Models;

namespace Hackathon_KNU.ViewModels;

public class SuggestionCommentResponse
{
    public int Id { get; set; }
    public long AuthorId { get; set; }
    public long SuggestionId { get; set; }
    public string Text { get; set; }
    public User Author { get; set; }

}