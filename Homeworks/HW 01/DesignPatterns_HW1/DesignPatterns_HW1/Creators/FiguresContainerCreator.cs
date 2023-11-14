using DesignPatterns_HW1.FiguresContainer;

namespace DesignPatterns_HW1.Creators
{
    public static class FiguresContainerCreator
    {
        public static IFiguresContainer Create(int count)
        {
            return new FiguresContainer.FiguresContainer(count);
        }
    }
}
