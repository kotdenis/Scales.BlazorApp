namespace Scales.BlazorApp.Infrastructure.Weighing
{
    public class TransportGenerator
    {
        public static TransportToWeigh GenerateTransport()
        {
            var random = new Random();
            return new TransportToWeigh
            {
                NumberOfAxles = random.Next(2, 5),
                Brand = DefaultTransportDatas.TransportBrands[random.Next(0, DefaultTransportDatas.TransportBrands.Count - 1)],
                Cargo = DefaultTransportDatas.TransportCargoes[random.Next(0, DefaultTransportDatas.TransportCargoes.Count - 1)],
                CarPlate = GenerateCarPlate(),
                Weight = random.Next(10000, 50000)
            };
        }

        private static string GenerateCarPlate()
        {
            string carPlate = "";
            var random = new Random();
            for (int i = 0; i < 6; i++)
            {
                var letter = DefaultTransportDatas.CarPlatesLetters[random.Next(0, DefaultTransportDatas.CarPlatesLetters.Count - 1)];
                var number = random.Next(0, 9);
                if (i < 1 || i > 3)
                    carPlate += letter;
                else if (i >= 1 && i < 4)
                    carPlate += number.ToString();
            }
            return carPlate;
        }
    }
}
