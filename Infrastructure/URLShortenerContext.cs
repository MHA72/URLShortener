using Infrastructure.Configuration;
using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class URLShortenerContext : DbContext
{
    public URLShortenerContext(DbContextOptions<URLShortenerContext> options) : base(options) {}
    public DbSet<UrlMapping>? UrlMappings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UrlMappingConfiguration());
    }
}