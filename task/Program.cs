using System;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Task<int> task = Task.Run(() =>
        {
            return 3 + 4;
        });

        task.ContinueWith((antecedent) =>
        {
            Console.WriteLine("The result is: " + antecedent.Result);  // Outputs "The result is: 7"
        });

        Console.ReadLine();  // Prevents app from exiting before task finishes
    }}
