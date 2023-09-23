namespace Hackathon_KNU.Models;

public class Article
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string LinkToBill { get; set; }
    public string AuthorName { get; set; }
    public string LinkToArticle { get; set; }
    public DateTime? CreatedAt = DateTime.Now;
    public IList<ArticleFeedback>? ArticleFeedbacks { get; set; }
}