using Infrastructure.Model;

namespace Infrastructure.Database.IRepository;

public interface IUrlRepository
{
    Task<UrlMapping> AddUrlShortener(string originalUrl, CancellationToken cancellationToken);
    Task<UrlMapping> GetUrlShortener(Guid id, CancellationToken cancellationToken);
}