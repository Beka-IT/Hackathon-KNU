using Hackathon_KNU.Models;

namespace Hackathon_KNU.ViewModels;

public class DocumentCommentResponse
{
    public int Id { get; set; }
    public long AuthorId { get; set; }
    public long DocumentId { get; set; }
    public string Text { get; set; }
    public User Author { get; set; }
}