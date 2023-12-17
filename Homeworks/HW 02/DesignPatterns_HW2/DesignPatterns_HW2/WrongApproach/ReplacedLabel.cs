using DesignPatterns_HW2.Labels;

namespace DesignPatterns_HW2.Decorators
{
    public class ReplacedLabel : LabelDecoratorBase
    {
        private readonly string _textToReplace;
        private readonly string _textToReplaceWith;

        private string Replace(string text)
        {
            return text.Replace(_textToReplace, _textToReplaceWith);
        }

        public ReplacedLabel(ILabel label, string textToReplace, string textToReplaceWith) : base(label)
        {
            _textToReplace = textToReplace;
            _textToReplaceWith = textToReplaceWith;
        }

        public override string GetText()
        {
            return Replace(base.GetText());
        }
    }
}
