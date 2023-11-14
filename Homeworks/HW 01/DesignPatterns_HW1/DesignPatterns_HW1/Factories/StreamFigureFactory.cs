using DesignPatterns_HW1.Creators;
using DesignPatterns_HW1.Figures;

namespace DesignPatterns_HW1.Factories
{
    public class StreamFigureFactory : IFigureFactory
    {
        private readonly Stream _stream;
        private readonly StreamReader _streamReader;

        public StreamFigureFactory(Stream stream)
        {
            _stream = stream;
            _streamReader = new StreamReader(_stream);
        }

        public IFigure Create()
        {
            return FigureCreator.CreateFigure(_streamReader.ReadLine()!);
        }

        public void Dispose()
        {
            _streamReader.Dispose();
            _stream.Dispose();

            GC.SuppressFinalize(this);
        }

        ~StreamFigureFactory()
        {
            Dispose();
        }
    }
}
