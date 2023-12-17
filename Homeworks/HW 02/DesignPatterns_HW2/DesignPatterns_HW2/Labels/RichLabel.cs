namespace DesignPatterns_HW2.Labels
{
    public class RichLabel : Label
    {
        private readonly string _color;
        private readonly string _size;
        private readonly string _font;

        public RichLabel(string text, string color, string size, string font) : base(text)
        {
            _color = color;
            _size = size;
            _font = font;
        }

        public override string GetText()
        {
            return $"<span style=\"color:{_color};font-size:{_size};font-family:{_font};\">{base.GetText()}</span>";
        }
    }
}
