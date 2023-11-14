namespace DesignPatterns_HW1.Common
{
    public interface IRandomGenerator
    {
        int Next(int minValue, int maxValue);

        double NextDouble();
    }

    public class RandomGenerator : IRandomGenerator
    {
        private readonly Random _random = new Random();

        public int Next(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }

        public double NextDouble()
        {
            return _random.NextDouble();
        }
    }
}
