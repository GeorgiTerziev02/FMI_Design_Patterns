using DesignPatterns_HW2.Random;

namespace DesignPatterns_HW2.Tests.Mocks
{
    public class RandomGeneratorMock : IRandomGenerator
    {
        public int NextReturnValue { get; set; } = 0;

        public int Next(int maxValue) => NextReturnValue;
    }
}
