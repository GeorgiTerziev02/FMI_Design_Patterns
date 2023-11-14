using DesignPatterns_HW1.Common;

namespace DesignPatterns_HW1.Figures
{
    public class Rectangle : IFigure
    {
        public const string NAME = "rectangle";

        public Rectangle(double a, double b)
        {
            if (a <= 0.0 || b <= 0.0)
            {
                throw new ArgumentException(ErrorMessages.INVALID_SIDE);
            }

            A = a;
            B = b;
        }

        public double A { get; }

        public double B { get; }

        public double Perimeter()
        {
            return (A + B) * 2;
        }

        public override string ToString()
        {
            return $"{NAME} {A} {B}";
        }

        public override bool Equals(object? obj) => this.Equals(obj as Rectangle);

        public bool Equals(Rectangle other)
        {
            if (other == null)
            {
                return false;
            }

            return (A.Equals(other.A) && B.Equals(other.B)) || (A.Equals(other.B) && B.Equals(other.A));
        }

        public object Clone()
        {
            return new Rectangle(A, B);
        }
    }
}
