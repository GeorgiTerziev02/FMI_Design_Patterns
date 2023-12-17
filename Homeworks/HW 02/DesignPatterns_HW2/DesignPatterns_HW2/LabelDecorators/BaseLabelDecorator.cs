using DesignPatterns_HW2.Labels;

namespace DesignPatterns_HW2.LabelDecorators
{
    public abstract class BaseLabelDecorator : ILabel
    {
        private readonly ILabel _label;

        public BaseLabelDecorator(ILabel label)
        {
            _label = label;
        }

        public virtual string GetText()
        {
            return _label.GetText();
        }
    }
}
