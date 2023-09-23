using System.Text.Json.Serialization;

namespace Hackathon_KNU.Models;

public class User
{
    public long Id { get; set; }
    public string Pin { get; set; }
    [JsonIgnore]
    public string Password { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronomyc { get; set; }
}