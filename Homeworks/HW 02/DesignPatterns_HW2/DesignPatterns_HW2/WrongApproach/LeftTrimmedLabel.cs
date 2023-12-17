using DesignPatterns_HW2.Labels;

namespace DesignPatterns_HW2.Decorators
{
    public class LeftTrimmedLabel : LabelDecoratorBase
    {
        public LeftTrimmedLabel(ILabel label) : base(label)
        { }

        public override string GetText()
        {
            return base.GetText().TrimStart();
        }
    }
}
