namespace Hackathon_KNU.ViewModels;

public class AddDocumentRequest
{
    public string TitleRu { get; set; }
    public string TitleKg { get; set; }
    public string ContentRu { get; set; }
    public string ContentKg { get; set; }
    public long AuthorId { get; set; }
}