using DesignPatterns_HW1.Common;

namespace DesignPatterns_HW1.Figures
{
    public class Circle : IFigure
    {
        public const string NAME = "circle";

        public Circle(double radius)
        {
            if (radius <= 0.0)
            {
                throw new ArgumentException(ErrorMessages.INVALID_RADIUS);
            }

            Radius = radius;
        }

        public double Radius { get; }

        public double Perimeter()
        {
            return 2 * Radius * Math.PI;
        }

        public override string ToString()
        {
            return $"{NAME} {Radius}";
        }

        public override bool Equals(object? obj) => this.Equals(obj as Circle);

        public bool Equals(Circle other)
        {
            if(other == null)
            {
                return false;
            }

            return Radius.Equals(other.Radius);
        }

        public object Clone()
        {
            return new Circle(Radius);
        }
    }
}
