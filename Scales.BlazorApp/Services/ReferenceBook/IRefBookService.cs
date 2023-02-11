using Scales.BlazorApp.Infrastructure.Auxiliary;
using Scales.BlazorApp.Infrastructure.Paging;

namespace Scales.BlazorApp.Services.ReferenceBook
{
    public interface IRefBookService
    {
        Task<HttpResponseMessage> GetReferenceBookAsync(PageParameters parameters);
        Task<HttpResponseMessage> CreateAsync(RefBookTransport refBookTransport);
        Task<HttpResponseMessage> UpdateAsync(RefBookTransport refBookTransport);
    }
}
