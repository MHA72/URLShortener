using System.Net;
using System.Text;
using Application.BusinessServices.IUseCase;
using Application.Mapper;
using Infrastructure.Database.IRepository;
using URLShortener.DTO;

namespace Application.BusinessServices.UseCase;

public class UrlUseCase : IUrlUseCase
{
    private readonly IUrlRepository _urlRepository;

    public UrlUseCase(IUrlRepository urlRepository)
    {
        _urlRepository = urlRepository;
    }

    public async Task<UrlMappingDto> AddUrlShortener(string originalUrl, CancellationToken cancellationToken)
    {
        var client = new HttpClient { BaseAddress = new Uri(originalUrl) };
        var content = new StringContent("", Encoding.UTF8, "application/json");
        var response = await client.PostAsync("", content, cancellationToken);
        var responseString = response.StatusCode;

        if (responseString != HttpStatusCode.OK)
            throw new Exception("The Address Is Incorrect");


        var result = await _urlRepository.AddUrlShortener(originalUrl, cancellationToken);
        return result.ToUrlMappingDto();
    }
}