namespace Hackathon_KNU.Models;

public class InitiatorOfDocument
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long DocumentId { get; set; }
    public string ContactDetail { get; set; }
}