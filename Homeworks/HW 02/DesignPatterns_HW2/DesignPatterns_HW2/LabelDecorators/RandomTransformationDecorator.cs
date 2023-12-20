using DesignPatterns_HW2.Labels;
using DesignPatterns_HW2.Random;
using DesignPatterns_HW2.Transformations;

namespace DesignPatterns_HW2.LabelDecorators
{
    public class RandomTransformationDecorator : BaseTransformationsContainerDecorator
    {
        private readonly IRandomGenerator _randomGenerator;

        public RandomTransformationDecorator(
            ILabel label,
            IList<ITextTransformation> transformations,
            IRandomGenerator randomGenerator
            ) : base(label, transformations)
        {
            _randomGenerator = randomGenerator;
        }

        public override string GetText()
        {
            var randomIndex = _randomGenerator.Next(transformations.Count);
            return transformations[randomIndex].Transform(base.GetText());
        }
    }
}
