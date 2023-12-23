namespace DesignPatterns_HW2.Transformations
{
    public class TrimRightTransformation : ITextTransformation
    {
        public string Transform(string text)
        {
            return text.TrimEnd();
        }

        public override bool Equals(object? obj) => Equals(obj as TrimRightTransformation);

        public bool Equals(TrimRightTransformation? other)
        {
            return other != null;
        }
    }
}
