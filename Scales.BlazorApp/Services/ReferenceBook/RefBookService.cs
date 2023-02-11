using Microsoft.AspNetCore.WebUtilities;
using Scales.BlazorApp.Constants;
using Scales.BlazorApp.Infrastructure.Auxiliary;
using Scales.BlazorApp.Infrastructure.Paging;
using System.Net.Http.Json;

namespace Scales.BlazorApp.Services.ReferenceBook
{
    public class RefBookService : IRefBookService
    {
        private readonly HttpClient _httpClient;
        public RefBookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> GetReferenceBookAsync(PageParameters parameters)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = parameters.PageNumber.ToString(),
                ["pageSize"] = parameters.PageSize.ToString()
            };
            Console.WriteLine("--> get reference");
            var response = await _httpClient.GetAsync(QueryHelpers.AddQueryString(UrlConstants.REFBOOK_URL + "/api/refbook/RefBook", queryStringParam));
            return response;
        }

        public async Task<HttpResponseMessage> CreateAsync(RefBookTransport refBookTransport)
        {
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                Content = JsonContent.Create(refBookTransport),
                RequestUri = new Uri(UrlConstants.REFBOOK_URL + "/api/refbook/RefBook")
            };

            var response = await _httpClient.SendAsync(request);
            return response;
        }

        public async Task<HttpResponseMessage> UpdateAsync(RefBookTransport refBookTransport)
        {
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                Content = JsonContent.Create(refBookTransport),
                RequestUri = new Uri(UrlConstants.REFBOOK_URL + "/api/refbook/RefBook")
            };
            var response = await _httpClient.SendAsync(request);
            return response;
        }
    }
}
