
using Scales.BlazorApp.Infrastructure.Auxiliary;
using Scales.BlazorApp.Infrastructure.Paging;

namespace Scales.BlazorApp.Services.Journal
{
    public interface IJournalService
    {
        Task<HttpResponseMessage> GetJournalAsync(PageParameters parameters);
        Task<HttpResponseMessage> GetJournalByDatesAsync(PageParameters parameters, DateTime startDate, DateTime endDate);
        Task<HttpResponseMessage> SaveWeighingDataAsync(TransportDto transportDto);
    }
}
