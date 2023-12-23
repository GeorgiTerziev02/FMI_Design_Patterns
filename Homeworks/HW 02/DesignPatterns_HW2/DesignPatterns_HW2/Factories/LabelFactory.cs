using DesignPatterns_HW2.Labels;

namespace DesignPatterns_HW2.Factories
{
    public interface ILabelFactory
    {
        ILabel CreateLabel(string text);

        ILabel CreateRichLabel(string text, string color, int size, string font);

        ILabel CreateHelpLabel(ILabel label, ILabel helpLabel);

        ILabel CreateCustomLabelProxy(int timeout);
    }

    public class LabelFactory : ILabelFactory
    {
        public ILabel CreateLabel(string text)
        {
            return new Label(text);
        }

        public ILabel CreateHelpLabel(ILabel label, ILabel helpLabel)
        {
            return new HelpLabel(label, helpLabel);
        }

        public ILabel CreateCustomLabelProxy(int timeout)
        {
            return new CustomLabelProxy(this, timeout);
        }

        public ILabel CreateRichLabel(string text, string color, int size, string font)
        {
            return new RichLabel(text, color, size, font);
        }
    }
}
