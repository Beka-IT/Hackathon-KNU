using Hackathon_KNU.Models;
using Hackathon_KNU.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_KNU.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class SuggestionsController : ControllerBase
{
    private readonly AppDbContext _db;
    public SuggestionsController(AppDbContext context)
    {
        _db = context;
    }

    [HttpGet]
    public IActionResult Get(long id, long userId)
    {
        var suggestion = _db.Suggestions.Find(id);
        if (suggestion is not null)
        {
            suggestion.Viewed = suggestion.Viewed + 1;
            _db.SaveChanges();

            var suggestionResponse = new SuggestionResponse
            {
                Id = suggestion.Id,
                Title = suggestion.Title,
                Content = suggestion.Content,
                Viewed = suggestion.Viewed,
                AuthorId = suggestion.AuthorId,
                Liked = _db.SuggestionUserLikes
                    .Any(x => x.SuggestionId == suggestion.Id && x.UserId == userId),
                Likes = _db.SuggestionUserLikes
                    .Where(x => x.SuggestionId == suggestion.Id)
                    .Count()
            };
            return Ok(suggestionResponse);
        }
        return Ok();
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        var suggestions = _db.Suggestions.ToList();

        var suggestionResponses = new List<SuggestionResponse>();
        foreach (var suggestion in suggestions)
        {
            var suggestionResponse = new SuggestionResponse
            {
                Id = suggestion.Id,
                Title = suggestion.Title,
                Content = suggestion.Content,
                Viewed = suggestion.Viewed,
                AuthorId = suggestion.AuthorId,
                Likes = _db.SuggestionUserLikes
                    .Where(x => x.SuggestionId == suggestion.Id)
                    .Count()
            };
            
            suggestionResponses.Add(suggestionResponse);
        }
        return Ok(suggestionResponses);
    }

    [HttpPost]
    public IActionResult Add(Suggestion suggestion)
    {
        if (suggestion is not null)
        {
            _db.Add(suggestion);
            _db.SaveChanges();
            return Ok();
        }

        return BadRequest();
    }

    [HttpPost]
    public IActionResult Like(LikeRequest req)
    {
        var newLike = new SuggestionUserLikes { SuggestionId = req.SuggestionId, UserId = req.UserId };
        _db.Add(newLike);
        _db.SaveChanges();
        
        return Ok();
    }

    [HttpPost]
    public IActionResult AddComment(SuggestionComment comment)
    {
        
        return Ok();
    }
}