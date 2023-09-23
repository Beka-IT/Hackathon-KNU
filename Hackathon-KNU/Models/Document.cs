namespace Hackathon_KNU.Models;

public class Document
{
    public long Id { get; set; }
    public string TitleRu { get; set; }
    public string TitleKg { get; set; }
    public string Authors { get; set; }
    public string Content { get; set; }
    public long Viewed { get; set; }
    public long AuthorId { get; set; }
    public IList<SuggestionUserLikes> SuggestionUserLikes { get; set; }
}