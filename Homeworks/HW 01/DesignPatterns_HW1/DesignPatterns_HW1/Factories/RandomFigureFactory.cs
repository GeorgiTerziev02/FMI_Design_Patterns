using DesignPatterns_HW1.Common;
using DesignPatterns_HW1.Creators;
using DesignPatterns_HW1.Figures;

namespace DesignPatterns_HW1.Factories
{
    public class RandomFigureFactory : IFigureFactory
    {
        private const int MAX_DOUBLE_NUMBER = 100;
        private readonly static string[] _figureTypes = { Triangle.NAME, Rectangle.NAME, Circle.NAME };

        private readonly IRandomGenerator _randomGenerator;

        public RandomFigureFactory(IRandomGenerator randomGenerator)
        {
            this._randomGenerator = randomGenerator;
        }

        public IFigure Create()
        {
            var randomGeneratedString = GenerateRandomFigureString();
            return FigureCreator.CreateFigure(randomGeneratedString);
        }

        public void Dispose() { }

        private string GenerateRandomFigureType()
        {
            return _figureTypes[_randomGenerator.Next(0, _figureTypes.Length)];
        }

        private double GenerateRandomDouble()
        {
            return _randomGenerator.NextDouble() * MAX_DOUBLE_NUMBER;
        }

        public string GenerateValidTriangleString()
        {
            double a = 0, b = 0, c = 0;
            while (!Helper.IsValidTriangle(a, b, c))
            {
                a = GenerateRandomDouble();
                b = GenerateRandomDouble();
                c = GenerateRandomDouble();
            }
            return $"{Triangle.NAME} {a} {b} {c}";
        }

        private string GenerateRandomFigureString()
        {
            var type = GenerateRandomFigureType();

            switch (type)
            {
                case Triangle.NAME:
                    return GenerateValidTriangleString();
                case Rectangle.NAME:
                    return $"{type} {GenerateRandomDouble()} {GenerateRandomDouble()}";
                case Circle.NAME:
                    return $"{type} {GenerateRandomDouble()}";
                default:
                    throw new ArgumentException(ErrorMessages.INVALID_FIGURE_TYPE);
            }
        }
    }
}
