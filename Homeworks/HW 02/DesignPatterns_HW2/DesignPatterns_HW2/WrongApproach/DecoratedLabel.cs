using DesignPatterns_HW2.Labels;

namespace DesignPatterns_HW2.Decorators
{
    public class DecoratedLabel : LabelDecoratorBase
    {
        // TODO: should this come from the constructor
        private static readonly string _prefixDecoration = "-={";
        private static readonly string _postfixDecoration = "}=-";

        private static string Decorate(string text)
        {
            return $"{_prefixDecoration} {text} {_postfixDecoration}";
        }

        public DecoratedLabel(ILabel label) : base(label)
        { }

        public override string GetText()
        {
            return Decorate(base.GetText());
        }
    }
}
