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
            this._randomGenerator = randomGenerator;
        }

        public override string GetText()
        {
            var randomIndex = this._randomGenerator.Next(this.transformations.Count);
            return this.transformations[randomIndex].Transform(base.GetText());
        }
    }
}
