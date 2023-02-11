

using Scales.BlazorApp.Infrastructure.Auxiliary;
using Scales.BlazorApp.Infrastructure.Paging;

namespace Scales.BlazorApp.Infrastructure.States
{
    public class JournalState
    {
        public List<TransportDto> TransportDtos { get; set; } = new List<TransportDto>();
        public bool IsByDates { get; set; }
        public Metadata Metadata { get; set; } = new();
    }
}
