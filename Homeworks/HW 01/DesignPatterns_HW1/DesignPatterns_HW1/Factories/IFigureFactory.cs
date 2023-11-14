using DesignPatterns_HW1.Figures;

namespace DesignPatterns_HW1.Factories
{
    public interface IFigureFactory : IDisposable
    {
        IFigure Create();
    }
}
