using Boutique.Web.Models;
using Boutique.Web.Service.IService;

namespace Boutique.Web.Service;

public class BaseService : IBaseService
{
    private readonly IHttpClientFactory _httpClientFactory;
    public BaseService(IHttpClientFactory httpClientFactory) {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<ResponseDto?> SendAsync(RequestDto requestDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpRequestMessage message = new();
        message.Headers.Add("Accept", "application/json");
        //
        message.RequestUri
    }


}
