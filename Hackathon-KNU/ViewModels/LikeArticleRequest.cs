namespace Hackathon_KNU.ViewModels;

public class LikeArticleRequest
{
    public long UserId { get; set; }
    public long ArticleId { get; set; }
    public bool LikeOrUnlike { get; set; }
}