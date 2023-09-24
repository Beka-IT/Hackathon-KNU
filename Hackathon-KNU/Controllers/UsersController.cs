using System.Net;
using System.Text;
using System.Xml;
using Hackathon_KNU.Models;
using Hackathon_KNU.Services;
using Hackathon_KNU.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hackathon_KNU.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _db;
    public UsersController(AppDbContext context)
    {
        _db = context;
    }

    [HttpGet]
    public IActionResult SignIn()
    {
        return RedirectPermanent("https:balacn");
    }
}