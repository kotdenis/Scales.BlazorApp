

using Scales.BlazorApp.Infrastructure.Paging;

namespace Scales.BlazorApp.Infrastructure.PageHelpers
{
    public class PagingResponse<T> where T : class
    {
        public List<T> Items { get; set; } = new List<T>();
        public Metadata Metadata { get; set; } = new();
    }
}
