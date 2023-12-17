using DesignPatterns_HW2.Labels;
using DesignPatterns_HW2.Transformations;

namespace DesignPatterns_HW2.LabelDecorators
{
    public abstract class BaseTransformationsContainerDecorator : BaseLabelDecorator
    {
        protected readonly IList<ITextTransformation> transformations;

        protected BaseTransformationsContainerDecorator(ILabel label, IList<ITextTransformation> transformations) : base(label)
        {
            if (transformations == null || transformations.Count == 0)
            {
                throw new ArgumentException(nameof(transformations));
            }

            this.transformations = transformations;
        }
    }
}
