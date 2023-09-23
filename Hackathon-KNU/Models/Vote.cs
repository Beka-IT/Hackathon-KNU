namespace Hackathon_KNU.Models;

public class Vote
{
    public long UserId { get; set; }
    public long DocumentId { get; set; }
    public bool IsSupported { get; set; }
    public User? User { get; set; } = null!;
    public Document? Document { get; set; } = null!;
}