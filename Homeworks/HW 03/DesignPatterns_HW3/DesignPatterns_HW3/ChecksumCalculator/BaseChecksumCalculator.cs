using System.Security.Cryptography;

using DesignPatterns_HW3.ChecksuCalculator;
using DesignPatterns_HW3.Observer;

namespace DesignPatterns_HW3.ChecksumCalculator
{
    public abstract class BaseChecksumCalculator : BaseObservable, IChecksumCalculator
    {
        public string Calculate(Stream stream)
        {
            using var hashAlogithm = GetHashAlgorithm();
            return Calculate(hashAlogithm, stream);
        }

        protected abstract HashAlgorithm GetHashAlgorithm();

        private string Calculate(HashAlgorithm hashAlgorithm, Stream stream)
        {
            var buffer = new byte[4096];
            var bytesRead = 0;
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                hashAlgorithm.TransformBlock(buffer, 0, bytesRead, buffer, 0);
                Notify(this, new FileMessage("Processed bytes", (ulong)bytesRead));
            }
            hashAlgorithm.TransformFinalBlock(buffer, 0, bytesRead);
            return BitConverter.ToString(hashAlgorithm.Hash).Replace("-", string.Empty).ToLower();
        }
    }
}
