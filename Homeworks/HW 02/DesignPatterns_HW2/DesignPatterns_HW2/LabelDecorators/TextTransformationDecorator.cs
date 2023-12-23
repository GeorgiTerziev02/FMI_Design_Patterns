using DesignPatterns_HW2.Labels;
using DesignPatterns_HW2.Transformations;

namespace DesignPatterns_HW2.LabelDecorators
{
    public class TextTransformationDecorator : BaseLabelDecorator
    {
        private readonly ITextTransformation _transformation;

        public TextTransformationDecorator(ILabel label, ITextTransformation transformation) 
            : base(label)
        {
            _transformation = transformation;
        }

        public override string GetText()
        {
            return _transformation.Transform(base.GetText());
        }

        public override bool Equals(object? obj) => Equals(obj as TextTransformationDecorator);

        public bool Equals(TextTransformationDecorator? decorator)
        {
            if (decorator == null)
            {
                return false;
            }

            return _transformation.Equals(decorator._transformation);
        }
    }
}
