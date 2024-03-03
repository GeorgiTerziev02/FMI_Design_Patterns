using System.Security.Cryptography;

using DesignPatterns_HW3.ChecksumCalculator;

namespace DesignPatterns_HW3.ChecksuCalculator
{
    public class MD5ChecksumCalculator : BaseChecksumCalculator
    {
        protected override HashAlgorithm GetHashAlgorithm()
        {
            return MD5.Create();
        }
    }
}
