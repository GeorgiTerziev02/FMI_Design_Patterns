using DesignPatterns_HW2.Labels;

namespace DesignPatterns_HW2.Decorators
{
    public class CensoredLabel : LabelDecoratorBase
    {
        private readonly string _toCensor;

        private string Censor(string text)
        {
            return text.Replace(_toCensor, new string('*', _toCensor.Length));
        }

        public CensoredLabel(ILabel label, string toCensor) : base(label)
        {
            _toCensor = toCensor;
        }

        public override string GetText()
        {
            return Censor(base.GetText());
        }
    }
}
