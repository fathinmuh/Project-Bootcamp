using System;
using System.IO;
namespace FileHandlinDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string SourceFilePath = @"C:\Users\Batch 12\Documents\MyFile.txt";
            string DestinationFilePath = @"C:\Users\Batch 12\Documents\MyFile2.txt";

            if (File.Exists(SourceFilePath))
            {
                File.Copy(SourceFilePath, DestinationFilePath);
                string lines= File.ReadAllText(DestinationFilePath);
                Console.WriteLine(lines);
            }
            else
            {
                Console.WriteLine("MyFile.txt File Does Not Exists in D Directory");
            }
            Console.ReadKey();
        }
    }
}