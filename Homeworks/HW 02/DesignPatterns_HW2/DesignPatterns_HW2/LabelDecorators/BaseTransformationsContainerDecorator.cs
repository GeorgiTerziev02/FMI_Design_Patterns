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

        public override bool Equals(object? obj) => Equals(obj as BaseTransformationsContainerDecorator);


        public bool Equals(BaseTransformationsContainerDecorator? other)
        {
            if (other == null || other.transformations.Count != transformations.Count)
            {
                return false;
            }

            // The order matters
            for (int i = 0; i < transformations.Count; i++)
            {
                if (!transformations[i].Equals(other.transformations[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
