namespace DesignPatterns_HW2.Transformations
{
    public class CensorTransformation : ITextTransformation
    {
        private static readonly char CENSOR_SYMBOL = '*';
        private readonly string _toCensor;

        public CensorTransformation(string toCensor)
        {
            _toCensor = toCensor;
        }

        public string Transform(string text)
        {
            return text.Replace(_toCensor, new string(CENSOR_SYMBOL, _toCensor.Length));
        }

        public override bool Equals(object? obj) => Equals(obj as CensorTransformation);

        public bool Equals(CensorTransformation? other)
        {
            if(other == null)
            {
                return false;
            }

            return _toCensor == other._toCensor;
        }
    }
}
