using DesignPatterns_HW2.Factories;
using System.Diagnostics.Metrics;

namespace DesignPatterns_HW2.Labels
{
    public class CustomLabelProxy : ILabel
    {
        private readonly ILabelFactory _labelFactory;
        private readonly int _timeout = 0;
        private int _counter = 0;
        private ILabel _label = null;

        public CustomLabelProxy(ILabelFactory labelFactory, int timeout)
        {
            this._labelFactory = labelFactory;
            this._timeout = timeout;
        }

        private void CreateLabel()
        {
            _label = _labelFactory.Create(Console.ReadLine()!);
        }

        public string GetText()
        {
            // TODO: prompt when timeout is hit
            if(_label == null)
            {
                // get type to create
                // pass to factory
                CreateLabel();
            }
            else if(_counter == _timeout)
            {
                // TODO: promp user to change text
                CreateLabel();
            }
            else if(_counter < _timeout)
            {
                _counter++;
            }

            return _label.GetText();
        }
    }
}
