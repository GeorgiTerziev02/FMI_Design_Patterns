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
    }
}
