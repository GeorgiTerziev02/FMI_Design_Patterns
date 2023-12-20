using DesignPatterns_HW2.Factories;

namespace DesignPatterns_HW2.Labels
{
    public class CustomLabelProxy : ILabel
    {
        private readonly ILabelFactory _labelFactory;
        private readonly int _timeout = 0;
        private int _counter = 0;
        private ILabel? _label = null;

        public CustomLabelProxy(ILabelFactory labelFactory, int timeout)
        {
            _labelFactory = labelFactory;
            _timeout = timeout;
        }

        private void ReadLabel()
        {
            _label = _labelFactory.Create(Console.ReadLine()!);
        }

        public string GetText()
        {
            if(_label == null)
            {
                // TODO: get type to create then pass to factory
                ReadLabel();
            }
            else if(_counter == _timeout)
            {
                Console.WriteLine("Enter 1(true) or 0(false)");
                var response = bool.Parse(Console.ReadLine()!);

                if(response)
                {
                    ReadLabel();
                }
            }
            else if(_counter < _timeout)
            {
                _counter++;
            }

            return _label.GetText();
        }
    }
}
