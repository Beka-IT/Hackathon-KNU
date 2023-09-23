namespace Hackathon_KNU.ViewModels;

public class AddInitiatorRequest
{
    public long UserId { get; set; }
    public long DocumentId { get; set; }
    public string ContactDetail { get; set; }
}