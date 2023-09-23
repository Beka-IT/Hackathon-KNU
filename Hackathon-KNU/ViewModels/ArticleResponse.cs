namespace Hackathon_KNU.ViewModels;

public class ArticleResponse
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string LinkToBill { get; set; }
    public string AuthorName { get; set; }
    public string LinkToArticle { get; set; }
    public DateTime? CreatedAt = DateTime.Now;
    public int Likes { get; set; }
    public int Unlikes { get; set; }
}