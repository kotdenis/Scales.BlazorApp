namespace Scales.BlazorApp.Infrastructure.Weighing
{
    public interface IWeighingSimulator
    {
        TransportToWeigh GenerateTransportDataForWeighing();
        List<float> AxlesList { get; }
        Queue<float> WeighingQueue { get; }
    }
}
