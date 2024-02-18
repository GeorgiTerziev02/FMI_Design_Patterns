using DesignPatterns_HW3.ChecksuCalculator;
using DesignPatterns_HW3.FileSystemBuilder;
using DesignPatterns_HW3.Observer;
using DesignPatterns_HW3.Visitor;

namespace DesignPatterns_HW3
{
    public class Program
    {
        public static void Main()
        {
            GenerateOneGigabyteFile();
            Console.WriteLine("Enter path to file/folder: ");
            //var path = Console.ReadLine();

            var path = "../../../../HashTestFolder";
            var singleFilePath = "../../../../HashTestFolder/TestFile1.txt";
            var checksumCalculator = new MD5ChecksumCalculator();
            var 
                fileSystemProvider = new FileSystemProvider.FileSystemProvider();
            var fileSystemBuilder = new FileSystemNotFollowingShortcutBuilder(fileSystemProvider);

            var result1 = fileSystemBuilder.Build(path);
            var result2 = fileSystemBuilder.Build(singleFilePath);

            var visitor1 = new ReportWriterVisitor(Console.OpenStandardOutput());
            Console.WriteLine("First visitor:");
            Console.WriteLine("First visit");
            result1.Accept(visitor1);
            Console.WriteLine(value: "Second visit");
            result2.Accept(visitor1);

            var visitor2 = new HashStreamWriterVisitor(checksumCalculator, fileSystemProvider);
            visitor2.Attach(new ProgressReporter(Console.OpenStandardOutput()));
            Console.WriteLine();
            Console.WriteLine("Second visitor:");
            Console.WriteLine("First visit");
            result1.Accept(visitor2);
            Console.WriteLine("Second visit");
            result2.Accept(visitor2);
        }

        public static void GenerateOneGigabyteFile()
        {
            var random = new Random();
            var bytes = new byte[1024 * 1024 * 1024];
            random.NextBytes(bytes);
            SystemFile.WriteAllBytes("../../../../HashTestFolder/1GB.txt", bytes);
        }
    }
}
