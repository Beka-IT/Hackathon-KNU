using Hackathon_KNU.Models;
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
        }
        return Ok(document);
    }

    [HttpPost]
    public IActionResult Add(Document document)
    {
        if (document is not null)
        {
            _db.Add(document);
            _db.SaveChanges();
            return Ok();
        }

        return BadRequest();
    }
}