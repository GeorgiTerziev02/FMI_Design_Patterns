namespace DesignPatterns_HW2.Transformations
{
    public class CensorTransformation : ITextTransformation
    {
        private readonly string _toCensor;

        public CensorTransformation(string toCensor)
        {
            _toCensor = toCensor;
        }

        public string Transform(string text)
        {
            return text.Replace(_toCensor, new string('*', _toCensor.Length));
        }
    }
}
