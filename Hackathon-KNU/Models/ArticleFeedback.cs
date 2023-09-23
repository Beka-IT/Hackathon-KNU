namespace Hackathon_KNU.Models;

public class ArticleFeedback
{
    public long UserId { get; set; }
    public long ArticleId { get; set; }
    public bool LikeOrUnlike { get; set; }
    public User User { get; set; } = null!;
    public Article Aritcle { get; set; } = null!;
}