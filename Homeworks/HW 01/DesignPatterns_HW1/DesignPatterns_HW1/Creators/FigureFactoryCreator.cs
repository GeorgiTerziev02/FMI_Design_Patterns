using System.ComponentModel;
using DesignPatterns_HW1.Common;
using DesignPatterns_HW1.Factories;
using DesignPatterns_HW1.Providers;

namespace DesignPatterns_HW1.Creators
{
    public enum FigureFactoryType
    {
        Random = 1,
        Console = 2,
        File = 3
    }

    public interface IFigureFactoryCreator
    {
        IFigureFactory CreateFactory(string input);
    }

    public class FigureFactoryCreator : IFigureFactoryCreator
    {
        private readonly IRandomGeneratorProvider _randomGeneratorProvider;
        private readonly IStreamProvider _streamProvider;

        public FigureFactoryCreator(IRandomGeneratorProvider randomGeneratorProvider, IStreamProvider streamProvider)
        {
            this._randomGeneratorProvider = randomGeneratorProvider;
            this._streamProvider = streamProvider;
        }

        public IFigureFactory CreateFactory(string input)
        {
            var tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (!Enum.TryParse(tokens[0], out FigureFactoryType factoryType))
            {
                throw new InvalidEnumArgumentException(ErrorMessages.INVALID_FACTORY_TYPE);
            }

            switch (factoryType)
            {
                case FigureFactoryType.Random:
                    return new RandomFigureFactory(_randomGeneratorProvider.GetRandomGenerator());
                case FigureFactoryType.Console:
                    return new StreamFigureFactory(_streamProvider.GetStdIn());
                case FigureFactoryType.File:
                    {
                        if (tokens.Length != 2)
                        {
                            throw new ArgumentException(ErrorMessages.INVALID_INPUT);
                        }
                        return new StreamFigureFactory(_streamProvider.OpenFileForRead(tokens[1]));
                    }
                default:
                    throw new InvalidEnumArgumentException(ErrorMessages.INVALID_FACTORY_TYPE);
            }
        }
    }
}
