

using Scales.BlazorApp.Infrastructure.Auxiliary;
using Scales.BlazorApp.Infrastructure.Paging;

namespace Scales.BlazorApp.Infrastructure.States
{
    public class RefBookState
    {
        public List<RefTransportDto> RefTransportDtos { get; set; } = new List<RefTransportDto>();
        public Metadata Metadata { get; set; } = new();
        public PageParameters PageParameters { get; set; } = new();
    }
}
