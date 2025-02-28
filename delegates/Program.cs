// Define a generic delegate
delegate void ProgressReporter(int percentComplete);

class Program
{
    static void Main()
    {
            void WriteProgressToConsole(int percentComplete)
            {
                Console.WriteLine("delegate 1 " + percentComplete);
            }

            void WriteProgressToFile(int percentComplete)
            {
                // System.IO.File.WriteAllText("progress.txt", percentComplete.ToString());
                Console.WriteLine("delegate 2 " + 2*percentComplete);
            }

            // Create a multicast delegate
            ProgressReporter reporter = WriteProgressToConsole;
            reporter += WriteProgressToFile;

            reporter(10);
    }
}