using DesignPatterns_HW1.Common;

namespace DesignPatterns_HW1.Figures
{
    public class Triangle : IFigure
    {
        public const string NAME = "triangle";

        public Triangle(double a, double b, double c)
        {
            if (a <= 0.0 || b <= 0.0 || c <= 0.0)
            {
                throw new ArgumentException(ErrorMessages.INVALID_SIDE);
            }

            if (!Helper.IsValidTriangle(a, b, c))
            {
                throw new ArgumentException(ErrorMessages.INVALID_TRIANGLE);
            }

            A = a;
            B = b;
            C = c;
        }

        public double A { get; }

        public double B { get; }

        public double C { get; }

        public double Perimeter()
        {
            return A + B + C;
        }

        public override string ToString()
        {
            return $"{NAME} {A} {B} {C}";
        }

        public override bool Equals(object? obj) => this.Equals(obj as Triangle);

        public bool Equals(Triangle other)
        {
            if (other == null)
            {
                return false;
            }

            var currentSides = new[] { A, B, C };
            var otherSides = new[] { other.A, other.B, other.C };

            // TODO: overhead
            return currentSides.OrderBy(x => x).SequenceEqual(otherSides.OrderBy(x => x));
        }

        public object Clone()
        {
            return new Triangle(A, B, C);
        }
    }
}
