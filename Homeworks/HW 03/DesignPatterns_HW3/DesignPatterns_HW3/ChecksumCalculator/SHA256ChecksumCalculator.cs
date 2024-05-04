using System.Security.Cryptography;

namespace DesignPatterns_HW3.ChecksumCalculator
{
    public class SHA256ChecksumCalculator : BaseChecksumCalculator
    {
        protected override HashAlgorithm GetHashAlgorithm()
        {
            return SHA256.Create();
        }
    }
}
