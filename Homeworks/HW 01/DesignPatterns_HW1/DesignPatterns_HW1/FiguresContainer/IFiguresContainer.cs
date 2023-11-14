using DesignPatterns_HW1.Figures;

namespace DesignPatterns_HW1.FiguresContainer
{
    public interface IFiguresContainer
    {
        int Count { get; }

        IFigure this[int index] { get; }

        void Add(IFigure figure);

        string List();

        void RemoveAt(int index);

        void DuplicateAt(int index);

        void WriteToStream(Stream stream);
    }
}
