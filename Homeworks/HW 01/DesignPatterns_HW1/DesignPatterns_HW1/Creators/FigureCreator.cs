using DesignPatterns_HW1.Common;
using DesignPatterns_HW1.Figures;

namespace DesignPatterns_HW1.Creators
{
    public static class FigureCreator
    {
        public static IFigure CreateFigure(string input)
        {
            var tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length < 2)
            {
                throw new ArgumentException(ErrorMessages.INVALID_INPUT);
            }

            switch (tokens[0])
            {
                case Triangle.NAME:
                    {
                        Helper.DoubleParseTokens(tokens, 4, out double[] sides);

                        return new Triangle(sides[0], sides[1], sides[2]);
                    }
                case Rectangle.NAME:
                    {
                        Helper.DoubleParseTokens(tokens, 3, out double[] sides);

                        return new Rectangle(sides[0], sides[1]);
                    }
                case Circle.NAME:
                    {
                        Helper.DoubleParseTokens(tokens, 2, out double[] sides);

                        return new Circle(sides[0]);
                    }
                default:
                    throw new ArgumentException(ErrorMessages.INVALID_FIGURE_TYPE);
            }
        }
    }
}
