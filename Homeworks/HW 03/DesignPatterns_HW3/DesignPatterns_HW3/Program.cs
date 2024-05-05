using DesignPatterns_HW3.ChecksumCalculator;
using DesignPatterns_HW3.FileSystemBuilder;
using DesignPatterns_HW3.Reporter;
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

            var path = "..\\..\\..\\..\\HashTestFolder";
            var singleFilePath = "..\\..\\..\\..\\HashTestFolder\\TestFile1.txt";

            Console.WriteLine("Enter hash algorithm");
            //var algorithm = Console.ReadLine();
            var algorithm = "MD5";
            var checksumCalculatorFactory = new ChecksumCalculatorFactory();
            var checksumCalculator = checksumCalculatorFactory.Create(algorithm);

            var fileSystemProvider = new FileSystemProvider.FileSystemProvider();

            Console.WriteLine("Do you want to follow links? y/n");
            var response = Console.ReadLine();

            IFileSystemBuilder fileSystemBuilder = response == "y"
                ? new FileSystemFollowingShortcutsBuilder(fileSystemProvider)
                : new FileSystemNotFollowingShortcutBuilder(fileSystemProvider);


            var result1 = fileSystemBuilder.Build(path);
            var result2 = fileSystemBuilder.Build(singleFilePath);

            var visitor1 = new ReportWriterVisitor(Console.OpenStandardOutput());
            Console.WriteLine("First visitor - normal reporter:");
            Console.WriteLine("First visit");
            result1.Accept(visitor1);
            Console.WriteLine(value: "Second visit");
            result2.Accept(visitor1);

            var visitor2 = new HashStreamWriterVisitor(Console.OpenStandardOutput(), checksumCalculator, fileSystemProvider);

            var progressReporter = new ProgressReporter(Console.OpenStandardOutput());
            visitor2.Attach(progressReporter);
            Console.WriteLine();
            Console.WriteLine("Second visitor - hash stream writer:");
            Console.WriteLine("First visit");
            progressReporter.StartTimer(result1.Size);
            result1.Accept(visitor2);
            var takenTime1 = progressReporter.EndTimer();
            Console.WriteLine($"Time taken {takenTime1}ms");

            visitor2.Reset();
            Console.WriteLine("Second visit");
            progressReporter.StartTimer(result2.Size);
            result2.Accept(visitor2);
            progressReporter.EndTimer();
            var takenTime2 = progressReporter.EndTimer();
            Console.WriteLine($"Time taken {takenTime2}ms");
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
