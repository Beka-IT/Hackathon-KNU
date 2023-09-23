using Hackathon_KNU.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_KNU;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Vote> Votes { get; set; }
    public DbSet<InitiatorOfDocument> InitiatorsOfDocument { get; set; }
    public DbSet<Suggestion> Suggestions { get; set; }
    public DbSet<SuggestionComment> SuggestionComments { get; set; }
    public DbSet<DocumentComment> DocumentComments { get; set; }
    public DbSet<SuggestionUserLikes> SuggestionUserLikes { get; set; }
    public DbSet<ArticleFeedback> ArticleFeedbacks { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SuggestionUserLikes>().HasKey(sc => new { sc.UserId, sc.SuggestionId });
        modelBuilder.Entity<ArticleFeedback>().HasKey(sc => new { sc.UserId, sc.ArticleId });
        modelBuilder.Entity<Vote>().HasKey(sc => new { sc.UserId, sc.DocumentId });
    }

}