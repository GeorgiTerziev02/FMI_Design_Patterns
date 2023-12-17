using DesignPatterns_HW2.Labels;

namespace DesignPatterns_HW2.Decorators
{
    public abstract class LabelDecoratorBase : ILabel
    {
        protected readonly ILabel _label;

        protected LabelDecoratorBase(ILabel label)
        {
            _label = label;
        }

        public virtual string GetText()
        {
            return _label.GetText();
        }
    }
}
