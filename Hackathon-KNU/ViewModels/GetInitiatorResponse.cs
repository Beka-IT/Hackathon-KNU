using Hackathon_KNU.Models;

namespace Hackathon_KNU.ViewModels;

public class GetInitiatorResponse
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long DocumentId { get; set; }
    public string ContactDetail { get; set; }
    public User User { get; set; }
}