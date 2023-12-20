using DesignPatterns_HW2.Labels;
using DesignPatterns_HW2.Transformations;

namespace DesignPatterns_HW2.LabelDecorators
{
    public class TextTransformationlDecorator : BaseLabelDecorator
    {
        private readonly ITextTransformation _transformation;

        public TextTransformationlDecorator(ILabel label, ITextTransformation transformation) 
            : base(label)
        {
            _transformation = transformation;
        }

        public override string GetText()
        {
            return _transformation.Transform(base.GetText());
        }
    }
}
