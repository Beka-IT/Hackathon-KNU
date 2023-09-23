using Hackathon_KNU.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_KNU;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<Suggestion> Suggestions { get; set; }
    public DbSet<SuggestionComment> SuggestionComments { get; set; }
    public DbSet<SuggestionUserLikes> SuggestionUserLikes { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SuggestionUserLikes>().HasKey(sc => new { sc.UserId, sc.SuggestionId });
    }

}