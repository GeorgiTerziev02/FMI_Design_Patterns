namespace DesignPatterns_HW2.Transformations
{
    public class CompositeTextTransformation : ITextTransformation
    {
        private readonly IList<ITextTransformation> _transformations;

        public CompositeTextTransformation(IList<ITextTransformation> transformations)
        {
            _transformations = transformations;
        }

        public string Transform(string text)
        {
            foreach (var transformation in _transformations)
            {
                text = transformation.Transform(text);
            }

            return text;
        }
    }
}
