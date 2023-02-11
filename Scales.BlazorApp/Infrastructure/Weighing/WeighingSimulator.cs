using Scales.BlazorApp.Constants;
using System.Collections.Concurrent;

namespace Scales.BlazorApp.Infrastructure.Weighing
{
    public class WeighingSimulator : IWeighingSimulator
    {
        private Queue<float> _weighingQueue;
        private List<float> _axlesList;
        public WeighingSimulator()
        {
            _weighingQueue = new Queue<float>();
            _axlesList = new List<float>(6);
        }

        public Queue<float> WeighingQueue => _weighingQueue;
        public List<float> AxlesList => _axlesList;

        public TransportToWeigh GenerateTransportDataForWeighing()
        {
            SetInitialParams();
            var random = new Random();
            var transport = TransportGenerator.GenerateTransport();
            var weightOnAxle = Math.Round(transport.Weight / transport.NumberOfAxles);
            var delimiter = weightOnAxle;
            var splittedWeight = (float)Math.Round(transport.Weight / AppConstants.WEIGHING_PERIOD);
            var level = splittedWeight;
            var splitter = 1;
            _weighingQueue.Enqueue(0);
            for (int i = 0; i < transport.Weight; i += (int)splittedWeight)
            {
                if(splitter == 1)
                {
                    //amplitude = random.Next(-200, 200) + i;
                    _weighingQueue.Enqueue(i);
                }
                else
                {
                    var amplitude = random.Next(0, 200);
                    _weighingQueue.Enqueue((float)(level + amplitude));
                }
                   
                if (i > delimiter - splittedWeight * 2)
                {
                    level = (float)delimiter;
                    delimiter = weightOnAxle + delimiter;
                    splitter++;
                }
            }
            for(int i = 0; i < transport.NumberOfAxles; i++)
            {
                if (i % 2 == 0)
                    _axlesList.Add((float)(weightOnAxle - 100));
                else
                    _axlesList.Add((float)(weightOnAxle + 100));
            }
            return transport;
        }

        private void SetInitialParams()
        {
            _weighingQueue = new Queue<float>();
            _axlesList = new List<float>(6);
        }
    }
}
