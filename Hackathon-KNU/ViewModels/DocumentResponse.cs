using Hackathon_KNU.ViewModels;

namespace Hackathon_KNU.Models;

public class DocumentResponse
{
    public long Id { get; set; }
    public string TitleRu { get; set; }
    public string TitleKg { get; set; }
    public string ContentRu { get; set; }
    public string ContentKg { get; set; }
    public long Viewed { get; set; }
    public long AuthorId { get; set; }
    public bool IsReadyForVote { get; set; }
    public List<GetInitiatorResponse> Initiators { get; set; }
    public User Author { get; set; }
    public DateTime? CreatedAt { get; set; }
}