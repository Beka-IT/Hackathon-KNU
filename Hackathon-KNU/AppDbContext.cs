using Hackathon_KNU.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_KNU;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

}