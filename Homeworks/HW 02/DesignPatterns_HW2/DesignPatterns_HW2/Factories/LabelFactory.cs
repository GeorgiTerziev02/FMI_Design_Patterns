using DesignPatterns_HW2.Labels;

namespace DesignPatterns_HW2.Factories
{
    public interface ILabelFactory
    {
        ILabel Create(string text);
    }

    public class LabelFactory : ILabelFactory
    {
        public ILabel Create(string text)
        {
            return new Label(text);
        }
    }
}
