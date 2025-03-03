// Define a generic delegate
using System.Security.Cryptography.X509Certificates;

delegate void ProgressReporter(int percentComplete);



public class Perintah{
    public void WriteProgressToConsole(int percentComplete)
    {
        Console.WriteLine("delegate 1 " + percentComplete);
    }

    public void WriteProgressToConsole2(int percentComplete)
    {
        // System.IO.File.WriteAllText("progress.txt", percentComplete.ToString());
        Console.WriteLine("delegate 2 " + 2*percentComplete);
    }
}

class Program
{
    static void Main()
    {
            Perintah perintah = new Perintah();


            // Create a multicast delegate
            ProgressReporter reporter = perintah.WriteProgressToConsole;
            reporter += perintah.WriteProgressToConsole2;

            reporter(10);

            // Using Func
            Func<int, int, int> add = (x, y) => x + y;
            Console.WriteLine(add(2, 3));  // Outputs: 5
             // Using Action
            Action<string> printMessage = message => Console.WriteLine(message);
            printMessage("Hello, world!");  // Outputs: Hello, world!


    }
}