namespace DesignPatterns_HW2.Transformations
{
    public class DecorateTransformation : ITextTransformation
    {
        private readonly string _prefixDecoration;
        private readonly string _postfixDecoration;

        public DecorateTransformation(string prefixDecoration = "-={", string postfixDecoration = "}=-")
        {
            _prefixDecoration = prefixDecoration;
            _postfixDecoration = postfixDecoration;
        }

        public string Transform(string text)
        {
            return $"{_prefixDecoration} {text} {_postfixDecoration}";
        }
    }
}
