namespace DesignPatterns_HW2.Transformations
{
    public class TrimLeftTransformation : ITextTransformation
    {
        public string Transform(string text)
        {
            return text.TrimStart();
        }

        public override bool Equals(object? obj) => Equals(obj as TrimLeftTransformation);

        public bool Equals(TrimLeftTransformation? other)
        {
            return other != null;
        }
    }
}
