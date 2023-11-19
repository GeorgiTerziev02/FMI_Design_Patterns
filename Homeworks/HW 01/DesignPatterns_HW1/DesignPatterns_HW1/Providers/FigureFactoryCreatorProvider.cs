using DesignPatterns_HW1.Creators;

namespace DesignPatterns_HW1.Providers
{
    public interface IFigureFactoryCreatorProvider
    {
        IFigureFactoryCreator GetFigureFactoryCreator();
    }

    public class FigureFactoryCreatorProvider : IFigureFactoryCreatorProvider
    {
        public IFigureFactoryCreator GetFigureFactoryCreator()
        {
            IRandomGeneratorProvider randomGeneratorProvider = new RandomGeneratorProvider();
            IStreamProvider streamProvider = new StreamProvider();
            return new FigureFactoryCreator(randomGeneratorProvider, streamProvider);
        }
    }
}
