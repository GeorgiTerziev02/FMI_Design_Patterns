using DesignPatterns_HW3.Observer;

namespace DesignPatterns_HW3.ChecksuCalculator
{
    public interface IChecksumCalculator : IObservable
    {
        public string Calculate(Stream stream);
    }
}
