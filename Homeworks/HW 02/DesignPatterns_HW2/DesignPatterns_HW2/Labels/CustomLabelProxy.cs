using System.Diagnostics.Metrics;

namespace DesignPatterns_HW2.Labels
{
    public class CustomLabelProxy : ILabel
    {
        private int _counter = 0;
        private int _timeout = 0;
        private string _text = null;

        public CustomLabelProxy(int timeout)
        {
            this._timeout = timeout;
        }

        private void SetText(string text)
        {
            if(_counter == _timeout)
            {
                _counter = 0;
                _text = text;
            }
        }
        // TODO: is this expected?
        public string GetText()
        {
            if(string.IsNullOrWhiteSpace(_text))
            {
                _text = Console.ReadLine();
            }
            else if(_counter < _timeout)
            {
                _counter++;
            }

            return _text;
        }
    }
}
