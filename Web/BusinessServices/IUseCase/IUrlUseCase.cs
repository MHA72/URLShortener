using URLShortener.DTO;

namespace Application.BusinessServices.IUseCase;

public interface IUrlUseCase
{
    Task<UrlMappingDto> AddUrlShortener(string originalUrl, CancellationToken cancellationToken);
}