namespace DesignPatterns_HW2.Transformations
{
    public class NormalizeTransformation : ITextTransformation
    {
        public string Transform(string text)
        {
            var tokens = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return string.Join(' ', tokens);
        }

        public override bool Equals(object? obj) => Equals(obj as NormalizeTransformation);

        public bool Equals(NormalizeTransformation? other)
        {
            return other != null;
        }
    }
}
