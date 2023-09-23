namespace Hackathon_KNU.Models;

public class Vote
{
    public long Id { get; set; }
    public string UserId { get; set; }
    public string DocumentId { get; set; }
    public string IsSupported { get; set; }
}