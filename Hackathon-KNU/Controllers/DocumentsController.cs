using Hackathon_KNU.Helpers;
using Hackathon_KNU.Models;
using Hackathon_KNU.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon_KNU.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class DocumentsController : ControllerBase
{
    private readonly AppDbContext _db;
    public DocumentsController(AppDbContext context)
    {
        _db = context;
    }

    [HttpGet]
    public IActionResult Get(long id)
    {
        var document = _db.Documents.FirstOrDefault(x => x.Id == id);
        if(document is not null)
        {
            document.Viewed = document.Viewed + 1;
            _db.SaveChanges();

            var documentResponse = new DocumentResponse
            {
                Id = document.Id,
                TitleKg = document.TitleKg,
                TitleRu = document.TitleRu,
                ContentKg = document.ContentKg,
                ContentRu = document.ContentRu,
                Viewed = document.Viewed,
                AuthorId = document.AuthorId,
                IsReadyForVote = document.IsReadyForVote,
                Author = _db.Users.FirstOrDefault(x => x.Id == document.AuthorId),
                Initiators = GetInitiatorsByDocId(document.Id),
                CreatedAt = document.CreatedAt
            };
            return Ok(documentResponse);
        }
        return Ok();
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        var documents = _db.Documents.ToList();
        var documentResponses = new List<DocumentResponse>();
        foreach (var document in documents)
        {
            var documentResponse = new DocumentResponse
            {
                Id = document.Id,
                TitleKg = document.TitleKg,
                TitleRu = document.TitleRu,
                ContentKg = document.ContentKg,
                ContentRu = document.ContentRu,
                Viewed = document.Viewed,
                AuthorId = document.AuthorId,
                IsReadyForVote = document.IsReadyForVote,
                Author = _db.Users.FirstOrDefault(x => x.Id == document.AuthorId),
                Initiators = GetInitiatorsByDocId(document.Id),
                CreatedAt = document.CreatedAt
            };
            
            documentResponses.Add(documentResponse);
        }
        return Ok(documentResponses);
    }

    [HttpPost]
    public IActionResult Add(AddDocumentRequest document)
    {
        if (document is not null)
        {
            var newDocument = new Document()
            {
                AuthorId = document.AuthorId,
                TitleKg = document.TitleKg,
                TitleRu = document.TitleRu,
                ContentKg = document.ContentKg,
                ContentRu = document.ContentRu,
                CreatedAt = DateTime.Now
            };
            _db.Add(newDocument);
            _db.SaveChanges();
            return Ok();
        }

        return BadRequest();
    }

    [HttpPost]
    public IActionResult AddInitiator(AddInitiatorRequest req)
    {
        var newInitiator = new InitiatorOfDocument
        {
            DocumentId = req.DocumentId,
            UserId = req.UserId,
            ContactDetail = req.ContactDetail
        };
        
        _db.Add(newInitiator);
        _db.SaveChanges();

        var initiatorsCount = _db.InitiatorsOfDocument.Where(x => x.DocumentId == req.DocumentId).Count();
        if (initiatorsCount > 9)
        {
            var doc = _db.Documents.FirstOrDefault(x => x.Id == req.DocumentId);
            doc.IsReadyForVote = true;
            _db.SaveChanges();
        }
        
        return Ok();
    }
    
    [HttpGet]
    public List<GetInitiatorResponse> GetInitiators(long documentId)
    {
        return GetInitiatorsByDocId(documentId);
    }
    
    [HttpPost]
    public IActionResult AddComment(DocumentComment comment)
    {
        if (CensorTextHelper.IsCensored(comment.Text))
        {
            return Ok("Ваш коммент содержит цензурные слова!");
        }
        _db.Add(comment);
        _db.SaveChanges();
        
        return Ok();
    }
    
    [HttpGet]
    public List<DocumentCommentResponse> GetComments(long documentId)
    {
        var comments = _db.DocumentComments
            .Where(x => x.DocumentId == documentId)
            .Select(x => new DocumentCommentResponse
            {
                Id = x.Id,
                DocumentId = x.DocumentId,
                Text = x.Text,
                AuthorId = x.AuthorId,
                Author = _db.Users.FirstOrDefault(u => u.Id == x.AuthorId)
            }).ToList();

        return comments;
    }
    
    [NonAction]
    private List<GetInitiatorResponse> GetInitiatorsByDocId(long documentId)
    {
        var initiators = _db.InitiatorsOfDocument
            .Where(x => x.DocumentId == documentId)
            .Select(x => new GetInitiatorResponse
            {
                Id = x.Id,
                DocumentId = x.DocumentId,
                UserId = x.UserId,
                User = _db.Users.FirstOrDefault(u => u.Id == x.UserId)
            }).ToList();

        return initiators;
    }
}