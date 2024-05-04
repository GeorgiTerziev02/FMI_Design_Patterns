using DesignPatterns_HW3.ChecksuCalculator;

namespace DesignPatterns_HW3.ChecksumCalculator
{
    public interface IChecksumCalculatorFacory
    {
        IChecksumCalculator Create(string type);
    }

    public class ChecksumCalculatorFactory : IChecksumCalculatorFacory
    {
        public IChecksumCalculator Create(string type)
        {
            switch (type.ToLower()) {
                case "md5":
                    return new MD5ChecksumCalculator();
                case "sha256":
                    return new SHA256ChecksumCalculator();
                default:
                    throw new ArgumentException("Invalid checksum type", nameof(type));
            }
        }
    }
}
