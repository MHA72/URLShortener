using Infrastructure.Configuration;
using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace URLShortener.Context;

public class UrlShortenerContext : DbContext
{
    public UrlShortenerContext(DbContextOptions<UrlShortenerContext> options) : base(options) {}
    public DbSet<UrlMapping>? UrlMappings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UrlMappingConfiguration());
    }
}