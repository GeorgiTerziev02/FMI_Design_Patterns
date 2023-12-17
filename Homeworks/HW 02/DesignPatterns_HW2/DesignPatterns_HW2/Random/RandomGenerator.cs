namespace DesignPatterns_HW2.Random
{
    public interface IRandomGenerator
    {
        int Next(int maxValue);
    }

    public class RandomGenerator : IRandomGenerator
    {
        private readonly System.Random _random = new System.Random();

        public int Next(int maxValue)
        {
            return _random.Next(maxValue);
        }
    }
}
