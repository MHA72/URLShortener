using Infrastructure.Model;
using URLShortener.Context;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Database.IRepository;

namespace URLShortener.Database.Repository;

public class UrlRepository : IUrlRepository
{
    private readonly UrlShortenerContext _context;

    public UrlRepository(UrlShortenerContext context)
    {
        _context = context;
    }

    public async Task<UrlMapping> AddUrlShortener(string originalUrl, CancellationToken cancellationToken)
    {
        var urlShortener = new UrlMapping
        {
            OriginalUrl = originalUrl,
            ShortenedUrl = "https://MHA/" + Guid.NewGuid()
        };

        await _context.AddAsync(urlShortener, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return await GetUrlShortener(urlShortener.Id, cancellationToken);
    }

    public async Task<UrlMapping> GetUrlShortener(Guid id, CancellationToken cancellationToken)
    {
        return await _context.UrlMappings!.Where(mapping => mapping.Id == id).FirstAsync(cancellationToken);
    }
}