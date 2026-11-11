using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data;

public class PortfolioDbContext : DbContext
{
    public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options)
    {
    }

    public DbSet<Project> Projects { get; set; } = null!;
    public DbSet<Blogpost> Blogposts { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blogpost>().HasData(
            new Blogpost
            {
                Id = 1,
                Titel = "Blogpost 1",
                Inhoud = "Inhoud van eerste blogpost.",
                Publicatiedatum = new DateTime(2025, 1, 10)
            },
            new Blogpost
            {
                Id = 2,
                Titel = "Blogpost 2",
                Inhoud = "Inhoud van tweede blogpost.",
                Publicatiedatum = new DateTime(2025, 2, 5)
            }
        );
    }
}
