namespace DesignPatterns_HW2.Random
{
    public interface IRandomGeneratorProvider
    {
        IRandomGenerator GetRandomGenerator();
    }

    public class RandomGeneratorProvider : IRandomGeneratorProvider
    {
        public IRandomGenerator GetRandomGenerator()
        {
            return new RandomGenerator();
        }
    }
}
