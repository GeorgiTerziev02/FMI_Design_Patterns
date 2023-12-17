namespace DesignPatterns_HW2.Transformations
{
    public class DecorateTransformation : ITextTransformation
    {
        // TODO: should this come from the constructor
        private static readonly string _prefixDecoration = "-={";
        private static readonly string _postfixDecoration = "}=-";

        public string Transform(string text)
        {
            return $"{_prefixDecoration} {text} {_postfixDecoration}";
        }
    }
}
