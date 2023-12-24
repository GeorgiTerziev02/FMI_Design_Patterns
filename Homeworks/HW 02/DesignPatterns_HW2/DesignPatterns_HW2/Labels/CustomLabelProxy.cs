using DesignPatterns_HW2.Factories;

namespace DesignPatterns_HW2.Labels
{
    public class CustomLabelProxy : ILabel, IDisposable
    {
        private readonly ILabelFactory _labelFactory;
        private readonly Stream _inputStream;
        private readonly StreamReader _inputStreamReader;

        private readonly int _timeout = 0;
        private int _counter = 0;
        private ILabel? _label = null;

        public CustomLabelProxy(ILabelFactory labelFactory, Stream inputStream, int timeout)
        {
            _labelFactory = labelFactory;
            _inputStream = inputStream;
            _inputStreamReader = new StreamReader(_inputStream);
            _timeout = timeout;
        }

        private void ReadLabel()
        {
            _label = _labelFactory.CreateLabel(_inputStreamReader.ReadLine()!);
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
                Console.WriteLine("If you want to use new value enter -> 'True', keep the same -> 'False'");
                var response = bool.Parse(_inputStreamReader.ReadLine()!);

                if(response)
                {
                    ReadLabel();
                }
            }
            else if(_counter < _timeout)
            {
                _counter++;
            }

            return _label!.GetText();
        }

        public void Dispose()
        {
            _inputStreamReader.Dispose();
            _inputStream.Dispose();

            GC.SuppressFinalize(this);
        }

        ~CustomLabelProxy()
        {
            Dispose();
        }
    }
}
