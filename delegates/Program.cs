// Define a generic delegate
delegate void ProgressReporter(int percentComplete);

class Program
{
    static void Main()
    {
            void WriteProgressToConsole(int percentComplete)
            {
                Console.WriteLine(percentComplete);
            }

            void WriteProgressToFile(int percentComplete)
            {
                System.IO.File.WriteAllText("progress.txt", percentComplete.ToString());
            }

            // Create a multicast delegate
            ProgressReporter reporter = WriteProgressToConsole;
            reporter += WriteProgressToFile;

            reporter(10);
    }
}