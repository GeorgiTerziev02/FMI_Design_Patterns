namespace DesignPatterns_HW2.Labels
{
    public class Label : ILabel
    {
        private readonly string _text;

        public Label(string text)
        {
            this._text = text;
        }

        public virtual string GetText()
        {
            return this._text;
        }
    }
}
