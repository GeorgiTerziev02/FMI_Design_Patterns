namespace DesignPatterns_HW2.Labels
{
    public class HelpLabel : IHelpLabel
    {
        private readonly ILabel _label;
        private readonly ILabel _helpLabel;

        public HelpLabel(ILabel label, ILabel helpLabel)
        {
            _label = label;
            _helpLabel = helpLabel;
        }

        public string GetHelpText()
        {
            return _helpLabel.GetText();
        }

        public string GetText()
        {
            return _label.GetText();
        }
    }
}
