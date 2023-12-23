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

        public override bool Equals(object? obj) => Equals(obj as CompositeTextTransformation);

        public bool Equals(CompositeTextTransformation? other)
        {
            if (other == null)
            {
                return false;
            }

            if (_transformations.Count != other._transformations.Count)
            {
                return false;
            }

            for (int i = 0; i < _transformations.Count; i++)
            {
                if (!_transformations[i].Equals(other._transformations[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
