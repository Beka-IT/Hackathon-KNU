namespace Hackathon_KNU.Models;

public class Document
{
    public long Id { get; set; }
    public string TitleRu { get; set; }
    public string TitleKg { get; set; }
    public string ContentRu { get; set; }
    public string ContentKg { get; set; }
    public bool IsReadyForVote { get; set; }
    public long Viewed { get; set; }
    public DateTime CreatedAt { get; set; }  = DateTime.Now;
    public long AuthorId { get; set; }
    public IList<Vote>? Votes { get; set; }
}