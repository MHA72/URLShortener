using Infrastructure.Model;
using URLShortener.DTO;

namespace Application.Mapper;

public static class UrlMappingMapper
{
    public static UrlMappingDto ToUrlMappingDto(this UrlMapping urlMapping) =>
        new UrlMappingDto(urlMapping.OriginalUrl, urlMapping.ShortenedUrl);
}