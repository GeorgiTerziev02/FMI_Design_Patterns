using DesignPatterns_HW2.Labels;

namespace DesignPatterns_HW2.Decorators
{
    public class NormalizedLabel : LabelDecoratorBase
    {
        public static string Normalize(string text)
        {
            var tokens = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return string.Join(' ', tokens);
        }

        public NormalizedLabel(ILabel label) : base(label)
        { }

        public override string GetText()
        {
            return Normalize(base.GetText());
        }
    }
}
