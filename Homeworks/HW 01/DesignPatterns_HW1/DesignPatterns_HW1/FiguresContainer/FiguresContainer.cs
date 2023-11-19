using DesignPatterns_HW1.Common;
using DesignPatterns_HW1.Figures;
using System.Text;

namespace DesignPatterns_HW1.FiguresContainer
{
    public class FiguresContainer : IFiguresContainer
    {
        private readonly List<IFigure> _figures;

        public FiguresContainer(int count)
        {
            if(count <= 0)
            {
                throw new ArgumentException(ErrorMessages.INVALID_COUNT);
            }

            _figures = new List<IFigure>(count);
        }

        public int Count => _figures.Count;

        public int Capacity => _figures.Capacity;

        public IFigure this[int index]
        {
            get
            {
                AssertIndex(index);
                return _figures[index];
            }
        }

        public void Add(IFigure figure)
        {
            _figures.Add(figure);
        }

        public string List()
        {
            var stringBuilder = new StringBuilder();
            ForEach(figure => stringBuilder.AppendLine(figure.ToString()));

            return stringBuilder.ToString();
        }

        public void RemoveAt(int index)
        {
            AssertIndex(index);
            _figures.RemoveAt(index);
        }

        public void DuplicateAt(int index)
        {
            AssertIndex(index);
            var clonedFIgure = (IFigure)_figures[index].Clone();
            _figures.Insert(index + 1, clonedFIgure);
        }

        public void WriteToStream(Stream stream)
        {
            using var streamWriter = new StreamWriter(stream, leaveOpen: true);
            ForEach((figure) => streamWriter.WriteLine(figure.ToString()));
        }



        private void AssertIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(ErrorMessages.INVALID_INDEX);
            }
        }

        private void ForEach(Action<IFigure> action)
        {
            foreach (var figure in _figures)
            {
                action(figure);
            }
        }
    }
}
