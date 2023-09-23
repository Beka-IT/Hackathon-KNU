using Hackathon_KNU.Models;
using Hackathon_KNU.Services;
using Hackathon_KNU.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon_KNU.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ArticlesController : ControllerBase
{
    private readonly AppDbContext _db;
    public ArticlesController(AppDbContext context, TelegramBotService botService)
    {
        _db = context;
    }
    [HttpPost]
    public IActionResult Add(Article article)
    {
        if (article is not null)
        {
            _db.Add(article);
            _db.SaveChanges();
            return Ok();
        }

        return BadRequest();
    }
    
    [HttpPost]
    public IActionResult Like(LikeArticleRequest req)
    {
        var newLike = new ArticleFeedback { ArticleId = req.ArticleId, UserId = req.UserId, LikeOrUnlike = req.LikeOrUnlike};
        _db.Add(newLike);
        _db.SaveChanges();
        
        return Ok();
    }
    
    [HttpGet]
    public IActionResult Get(long id)
    {
        var article = _db.Articles.Find(id);
        if (article is not null)
        {
            var articleResponse = new ArticleResponse
            {
                Id = article.Id,
                Title = article.Title,
                LinkToBill = article.LinkToBill,
                AuthorName = article.AuthorName,
                LinkToArticle = article.LinkToArticle,
                CreatedAt = article.CreatedAt,
                Likes = _db.ArticleFeedbacks
                    .Where(x => x.ArticleId == article.Id && x.LikeOrUnlike).Count(),
                Unlikes = _db.ArticleFeedbacks
                    .Where(x => x.ArticleId == article.Id && !x.LikeOrUnlike).Count()
            };
            return Ok(articleResponse);
        }
        return Ok();
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        var articles = _db.Articles.ToList();

        var articleResponses = new List<ArticleResponse>();
        foreach (var article in articles)
        {
            var articleResponse = new ArticleResponse
            {
                Id = article.Id,
                Title = article.Title,
                LinkToBill = article.LinkToBill,
                AuthorName = article.AuthorName,
                LinkToArticle = article.LinkToArticle,
                CreatedAt = article.CreatedAt,
                Likes = _db.ArticleFeedbacks
                    .Where(x => x.ArticleId == article.Id && x.LikeOrUnlike).Count(),
                Unlikes = _db.ArticleFeedbacks
                    .Where(x => x.ArticleId == article.Id && !x.LikeOrUnlike).Count()
            };
            
            articleResponses.Add(articleResponse);
        }
        return Ok(articleResponses);
    }

}