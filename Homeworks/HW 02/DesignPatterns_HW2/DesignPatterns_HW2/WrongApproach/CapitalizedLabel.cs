using DesignPatterns_HW2.Labels;

namespace DesignPatterns_HW2.Decorators
{
    public class CapitalizedLabel : LabelDecoratorBase
    {
        private static string Capitalize(string text)
        {
            return text[0].ToString().ToUpper() + text.Substring(1);
        }

        public CapitalizedLabel(ILabel label) : base(label)
        { }

        public override string GetText()
        {
            return Capitalize(base.GetText());
        }
    }
}
