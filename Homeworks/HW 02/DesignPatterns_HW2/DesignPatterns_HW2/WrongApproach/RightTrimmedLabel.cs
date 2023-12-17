using DesignPatterns_HW2.Labels;

namespace DesignPatterns_HW2.Decorators
{
    public class RightTrimmedLabel : LabelDecoratorBase
    {
        public RightTrimmedLabel(ILabel label) : base(label)
        { }

        public override string GetText()
        {
            return base.GetText().TrimEnd();
        }
    }
}
