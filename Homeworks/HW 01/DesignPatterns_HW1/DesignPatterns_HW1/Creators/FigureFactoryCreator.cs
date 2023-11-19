using System.ComponentModel;
using DesignPatterns_HW1.Common;
using DesignPatterns_HW1.Factories;

namespace DesignPatterns_HW1.Creators
{
    public enum FigureFactoryType
    {
        Random = 1,
        Console = 2,
        File = 3
    }

    // TODO: check tests
    public static class FigureFactoryCreator
    {
        public static IFigureFactory CreateFactory(string input)
        {
            var tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (!Enum.TryParse(tokens[0], out FigureFactoryType factoryType))
            {
                throw new InvalidEnumArgumentException(ErrorMessages.INVALID_FACTORY_TYPE);
            }

            // TODO: stream creator
            switch (factoryType)
            {
                case FigureFactoryType.Random:
                    return new RandomFigureFactory(new RandomGenerator());
                case FigureFactoryType.Console:
                    return new StreamFigureFactory(Console.OpenStandardInput());
                case FigureFactoryType.File:
                    {
                        if (tokens.Length != 2)
                        {
                            throw new ArgumentException(ErrorMessages.INVALID_INPUT);
                        }
                        return new StreamFigureFactory(new FileStream(tokens[1], FileMode.Open, FileAccess.Read, FileShare.None));
                    }
                default:
                    throw new InvalidEnumArgumentException(ErrorMessages.INVALID_FACTORY_TYPE);
            }
        }
    }
}
