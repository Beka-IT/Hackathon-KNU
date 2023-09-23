namespace Hackathon_KNU.Models;

public class DocumentComment
{
    public int Id { get; set; }
    public long AuthorId { get; set; }
    public long DocumentId { get; set; }
    public string Text { get; set; }
}