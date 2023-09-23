using System.Text.Json.Serialization;
using Hackathon_KNU.Enums;

namespace Hackathon_KNU.Models;

public class User
{
    public long Id { get; set; }
    public string Pin { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronomyc { get; set; }
    public string WalletAddress { get; set; }
    public string PhoneNumber { get; set; }
    public RolesTypes Role { get; set; }
}