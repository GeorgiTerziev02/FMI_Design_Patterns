namespace DesignPatterns_HW2.Transformations
{
    public class ReplaceTransformation : ITextTransformation
    {
        private readonly string _toReplace;
        private readonly string _replaceWith;

        public ReplaceTransformation(string toReplace, string replaceWith)
        {
            _toReplace = toReplace;
            _replaceWith = replaceWith;
        }

        public string Transform(string text)
        {
            return text.Replace(_toReplace, _replaceWith);
        }

        public override bool Equals(object? obj) => Equals(obj as ReplaceTransformation);

        public bool Equals(ReplaceTransformation? other)
        {
            if(other == null)
            {
                return false;
            }

            return _toReplace == other._toReplace && _replaceWith == other._replaceWith;
        }
    }
}
