using DesignPatterns_HW3.ChecksuCalculator;

namespace DesignPatterns_HW3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter path to file/folder: ");
            //var path = Console.ReadLine();

            var path = "D:\\FMI HW\\Semester5\\Design Patterns\\FMI_Design_Patterns\\Homeworks\\HW 03\\DesignPatterns_HW3\\HashTestFolder";
            var checksumCalculator = new MD5ChecksumCalculator();

            Directory.GetFiles(path).ToList().ForEach(file =>
            {
                using var stream = File.OpenRead(file);
                var checksum = checksumCalculator.Calculate(stream);
                Console.WriteLine($"File: {file} | Checksum: {checksum}");
            });
        }
    }
}
