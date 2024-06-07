using Microsoft.AspNetCore.Mvc;
using Application.BusinessServices.IUseCase;
using URLShortener.DTO;

namespace URLShortener.Controller;

[ApiController]
[Route("")]
public class UrlController : ControllerBase
{
    private readonly IUrlUseCase _urlUseCase;

    public UrlController(IUrlUseCase urlUseCase)
    {
        _urlUseCase = urlUseCase;
    }

    [HttpPost("AddURL")]
    public async Task<ActionResult<UrlMappingDto>> GetCount(string url, CancellationToken cancellationToken) =>
        await _urlUseCase.AddUrlShortener(url, cancellationToken);
}