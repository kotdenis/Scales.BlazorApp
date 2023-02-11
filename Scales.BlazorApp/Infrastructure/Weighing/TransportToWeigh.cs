namespace Scales.BlazorApp.Infrastructure.Weighing
{
    public class TransportToWeigh
    {
        public float Weight { get; set; }
        public string CarPlate { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public int NumberOfAxles { get; set; }
    }
}
