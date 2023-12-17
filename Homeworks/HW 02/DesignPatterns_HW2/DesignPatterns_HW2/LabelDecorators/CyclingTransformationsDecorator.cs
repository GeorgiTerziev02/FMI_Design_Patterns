using DesignPatterns_HW2.Labels;
using DesignPatterns_HW2.Transformations;

namespace DesignPatterns_HW2.LabelDecorators
{
    public class CyclingTransformationsDecorator : BaseTransformationsContainerDecorator
    {
        private int currentTransformationIndex = 0;

        private int GetTransformationIndex()
        {
            var temp = currentTransformationIndex;
            currentTransformationIndex++;
            currentTransformationIndex %= transformations.Count;

            return temp;
        }

        public CyclingTransformationsDecorator(ILabel label, IList<ITextTransformation> transformations)
            : base(label, transformations)
        { }

        public override string GetText()
        {
            return transformations[GetTransformationIndex()].Transform(base.GetText());
        }
    }
}
