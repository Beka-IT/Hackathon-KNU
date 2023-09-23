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
    public async Task<IActionResult> Bot(string message)
    {
        var answer = await ChatGptService.SendMessage(message);
        return Ok(answer);
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
    
    [HttpPost]
    public User SignUp(SignUpRequest req)
    {
        var newUser = new User
        {
            Pin = req.Pin,
            Name = req.Name,
            Surname = req.Surname,
            Patronomyc = req.Patronomyc,
            PhoneNumber = req.PhoneNumber,
            WalletAddress = req.WalletAddress
        };
        
        _db.Add(newUser);
        _db.SaveChanges();
        
        return newUser;
    }
}