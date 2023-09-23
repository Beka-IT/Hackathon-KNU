namespace Hackathon_KNU.ViewModels;

public class VoteResponse
{
    public long UserId { get; set; }
    public long DocumentId { get; set; }
    public bool? IsSupported { get; set; }
}