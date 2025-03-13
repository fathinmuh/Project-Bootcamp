using System;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Task.Run(() => Console.WriteLine("Task running asynchronously"));
        Console.ReadLine();  // Block to prevent app from exiting before task finishes
    }
}