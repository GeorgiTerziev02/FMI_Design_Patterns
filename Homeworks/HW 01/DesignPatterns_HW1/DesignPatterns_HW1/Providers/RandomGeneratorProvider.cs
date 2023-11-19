using DesignPatterns_HW1.Common;

namespace DesignPatterns_HW1.Providers
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
