using Microsoft.AspNetCore.WebUtilities;
using Scales.BlazorApp.Constants;
using Scales.BlazorApp.Infrastructure.Auxiliary;
using Scales.BlazorApp.Infrastructure.Paging;
using System.Net.Http.Json;

namespace Scales.BlazorApp.Services.Journal
{
    public class JournalService : IJournalService
    {
        private readonly HttpClient _httpClient;
        public JournalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> GetJournalAsync(PageParameters parameters)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = parameters.PageNumber.ToString(),
                ["pageSize"] = parameters.PageSize.ToString()
            };
            var response = await _httpClient.GetAsync(QueryHelpers.AddQueryString(UrlConstants.JOURNAL_URL + "/api/journal/Journal", queryStringParam));

            return response;
        }

        public async Task<HttpResponseMessage> GetJournalByDatesAsync(PageParameters parameters, DateTime startDate, DateTime endDate)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = parameters.PageNumber.ToString(),
                ["pageSize"] = parameters.PageSize.ToString(),
                ["startDate"] = startDate.ToString("MM.dd.yyyy"),
                ["endDate"] = endDate.ToString("MM.dd.yyyy")
            };
            var response = await _httpClient.GetAsync(QueryHelpers.AddQueryString(UrlConstants.JOURNAL_URL + "/api/journal/Journal/bydate", queryStringParam));
            return response;
        }

        public async Task<HttpResponseMessage> SaveWeighingDataAsync(TransportDto transportDto)
        {
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                Content = JsonContent.Create(transportDto),
                RequestUri = new Uri(UrlConstants.JOURNAL_URL + "/api/journal/Journal")
            };
            var response = await _httpClient.SendAsync(request);
            return response;
        }
    }
}
