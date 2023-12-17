using DesignPatterns_HW2.Labels;

namespace DesignPatterns_HW2.LabelDecorators
{
    public abstract class BaseLabelDecorator : ILabel
    {
        private ILabel _label;

        public BaseLabelDecorator(ILabel label)
        {
            _label = label;
        }

        public virtual string GetText()
        {
            return _label.GetText();
        }

        public static ILabel RemoveDecoratorFrom(ILabel label, Type decoratorType)
        {
            if (label == null)
            {
                throw new ArgumentNullException(nameof(label));
            }

            if (decoratorType == null)
            {
                throw new ArgumentNullException(nameof(decoratorType));
            }

            if (label is BaseLabelDecorator labelDecorator)
            {
                return labelDecorator.RemoveDecorator(decoratorType);
            }

            return label;

        }

        // TODO: this does not remove based on the transformation type
        // the other approach with decorator for every transformation is better?
        // or this with the equals on decorators and transformations?
        public ILabel RemoveDecorator(Type decoratorType)
        {
            if(GetType() == decoratorType)
            {
                return _label;
            }

            if (_label is BaseLabelDecorator labelDecorator)
            {
                _label = labelDecorator.RemoveDecorator(decoratorType);
                return this;
            }

            return _label;
        }
    }
}
