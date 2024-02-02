﻿using DesignPatterns_HW3.ChecksuCalculator;
using DesignPatterns_HW3.FileSystemBuilder;
using DesignPatterns_HW3.Visitor;

namespace DesignPatterns_HW3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter path to file/folder: ");
            //var path = Console.ReadLine();

            var path = "D:\\FMI HW\\Semester5\\Design Patterns\\FMI_Design_Patterns\\Homeworks\\HW 03\\DesignPatterns_HW3\\HashTestFolder";
            var singleFilePath = "D:\\FMI HW\\Semester5\\Design Patterns\\FMI_Design_Patterns\\Homeworks\\HW 03\\DesignPatterns_HW3\\HashTestFolder\\TestFile1.txt";
            var checksumCalculator = new MD5ChecksumCalculator();
            var fileSystemProvider = new FileSystemProvider.FileSystemProvider();
            var fileSystemBuilder = new FileSystemNotFollowingShortcutBuilder(fileSystemProvider);

            var result1 = fileSystemBuilder.Build(path);
            var result2 = fileSystemBuilder.Build(singleFilePath);

            var visitor1 = new ReportWriterVisitor();
            Console.WriteLine("First visitor:");
            Console.WriteLine("First visit");
            result1.Accept(visitor1);
            Console.WriteLine("Second visit");
            result2.Accept(visitor1);

            var visitor2 = new HashStreamWriterVisitor(checksumCalculator, fileSystemProvider);
            Console.WriteLine("Second visitor:");
            Console.WriteLine("First visit");
            result1.Accept(visitor2);
            Console.WriteLine("Second visit");
            result2.Accept(visitor2);
        }
    }
}
