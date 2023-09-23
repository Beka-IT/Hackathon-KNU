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

    [HttpPost]
    public async Task<User> SignIn(SignInRequest req)
    {
        var user = _db.Users.FirstOrDefault(x => x.Pin == req.Pin);

        if (user is not null)
        {
            return user;
        }

        return null;
    }
}