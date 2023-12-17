namespace DesignPatterns_HW2.Transformations
{
    public class TrimLeftTransformation : ITextTransformation
    {
        public string Transform(string text)
        {
            return text.TrimStart();
        }
    }
}
