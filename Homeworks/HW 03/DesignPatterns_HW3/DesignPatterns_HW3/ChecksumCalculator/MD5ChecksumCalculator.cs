using System.Security.Cryptography;

namespace DesignPatterns_HW3.ChecksuCalculator
{
    public class MD5ChecksumCalculator : IChecksumCalculator
    {
        public string Calculate(Stream stream)
        {
            using var md5 = MD5.Create();
            var checksum = md5.ComputeHash(stream);
            return BitConverter.ToString(checksum).Replace("-", string.Empty).ToLower();
        }
    }
}
