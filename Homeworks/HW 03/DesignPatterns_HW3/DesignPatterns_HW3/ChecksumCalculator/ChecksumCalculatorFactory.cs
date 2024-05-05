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
            return type.ToLower() switch
            {
                "md5" => new MD5ChecksumCalculator(),
                "sha256" => new SHA256ChecksumCalculator(),
                _ => throw new ArgumentException("Invalid checksum type", nameof(type)),
            };
        }
    }
}
