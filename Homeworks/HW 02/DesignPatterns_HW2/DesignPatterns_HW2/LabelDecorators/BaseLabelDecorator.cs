using DesignPatterns_HW2.Labels;

namespace DesignPatterns_HW2.LabelDecorators
{
    public interface ILabelDecorator : ILabel
    {
        ILabel RemoveDecorator(ILabelDecorator decoratorToRemove);
    }

    public abstract class BaseLabelDecorator : ILabelDecorator
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

        public override bool Equals(object? obj) => Equals(obj as BaseLabelDecorator);

        public bool Equals(BaseLabelDecorator? other)
        {
            // This method will be called from child 
            // with the idea to remove a specific decorator
            // from the linked list of decorators.
            // the passed "decoratorToRemove" is mock decorator
            // with null label => labels should not be compared
            return other != null;
        }

        public static ILabel RemoveDecoratorFrom(ILabel label, ILabelDecorator decoratorToRemove)
        {
            if (label == null)
            {
                throw new ArgumentNullException(nameof(label));
            }

            if (decoratorToRemove == null)
            {
                throw new ArgumentNullException(nameof(decoratorToRemove));
            }

            if (label is ILabelDecorator labelDecorator)
            {
                return labelDecorator.RemoveDecorator(decoratorToRemove);
            }

            return label;

        }

        public ILabel RemoveDecorator(ILabelDecorator decoratorToRemove)
        {
            if(Equals(decoratorToRemove))
            {
                return _label;
            }

            if (_label is ILabelDecorator labelDecorator)
            {
                _label = labelDecorator.RemoveDecorator(decoratorToRemove);
                return this;
            }

            return _label;
        }
    }
}
