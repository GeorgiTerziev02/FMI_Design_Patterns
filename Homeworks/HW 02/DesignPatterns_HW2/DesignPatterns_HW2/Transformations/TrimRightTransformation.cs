namespace DesignPatterns_HW2.Transformations
{
    public class TrimRightTransformation : ITextTransformation
    {
        public string Transform(string text)
        {
            return text.TrimEnd();
        }
    }
}
