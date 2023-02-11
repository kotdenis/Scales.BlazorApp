using Scales.BlazorApp.Infrastructure.Errors;
using Scales.BlazorApp.Infrastructure.PageHelpers;
using Scales.BlazorApp.Infrastructure.Paging;
using System.Text.Json;

namespace Scales.BlazorApp.Services
{
    public static class ServiceExtensions
    {
        public static async Task<PagingResponse<T>> GetPagingResponseAsync<T>(this HttpResponseMessage response, string header) where T : class
        {
            var content = await response.Content.ReadAsStringAsync();
            response.Headers.TryGetValues(header, out IEnumerable<string>? values);
            return new PagingResponse<T>
            {
                Items = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(content)!,
                Metadata = values?.Count() > 0 ? JsonSerializer.Deserialize<Metadata>(values?.First()!)! : new Metadata()
            };
        }

        public static async Task<ErrorDetails> GetErrorDetailsAsync(this HttpResponseMessage response)
        {
            var error = new ErrorDetails();
            var content = await response.Content.ReadAsStringAsync();
            try
            {
                error = JsonSerializer.Deserialize<ErrorDetails>(content);
                error!.StatusCode = (int)response.StatusCode;
            }
            catch (Exception ex)
            {
                return new ErrorDetails { Message = ex.Message, StatusCode = (int)response.StatusCode };
            }
            return error;
        }
    }
}
