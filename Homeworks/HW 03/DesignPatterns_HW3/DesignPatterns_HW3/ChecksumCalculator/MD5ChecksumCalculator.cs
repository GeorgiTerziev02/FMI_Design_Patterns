using System.Drawing;
using System.Security.Cryptography;

namespace DesignPatterns_HW3.ChecksuCalculator
{
    public class MD5ChecksumCalculator : IChecksumCalculator
    {
        public string Calculate(Stream stream)
        {
            using var md5 = MD5.Create();
            var checksum = md5.ComputeHash(stream);
            stream.Position = 0;
            Console.WriteLine(CalculateWithBlocks(stream));
            return BitConverter.ToString(checksum).Replace("-", string.Empty).ToLower();
        }

        public string CalculateWithBlocks(Stream stream)
        {
            using var md5 = MD5.Create();

            var buffer = new byte[1024];
            var bytesRead = 0;
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                md5.TransformBlock(buffer, 0, bytesRead, buffer, 0);
            }
            md5.TransformFinalBlock(buffer, 0, bytesRead);
            return ToStringChecksum(md5.Hash);
        }

        // TODO: maybe move
        public string ToStringChecksum(byte[] checksum)
        {
            return BitConverter.ToString(checksum).Replace("-", string.Empty).ToLower();
        }
    }
}
