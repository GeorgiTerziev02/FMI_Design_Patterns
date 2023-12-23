using DesignPatterns_HW2.LabelDecorators;

namespace DesignPatterns_HW2.Transformations
{
    public class CapitalizeTransformation : ITextTransformation
    {
        public string Transform(string text)
        {
            if(string.IsNullOrWhiteSpace(text))
            {
                return "";
            }

            return text[0].ToString().ToUpper() + text.Substring(1);
        }

        public override bool Equals(object? obj) => Equals(obj as CapitalizeTransformation);

        public bool Equals(CapitalizeTransformation? other)
        {
            return other != null;
        }
    }
}
