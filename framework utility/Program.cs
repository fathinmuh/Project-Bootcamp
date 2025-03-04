using System.Diagnostics;

string name = Console.ReadLine();  // Read a line of input
Console.WriteLine("Hello, " + name);  // Output the entered name
int progress = 50;
Console.WriteLine("Progress: {0}%", progress);
Console.WindowWidth = 100;
Console.ForegroundColor = ConsoleColor.Gray;
Console.CursorLeft = 55;
Console.CursorTop = 5;
Console.WriteLine("Welcome to the console!");

// Save the current output writer
TextWriter oldOut = Console.Out;

// Redirect output to a file
using (TextWriter writer = File.CreateText("output.txt"))
{
    Console.SetOut(writer);
    Console.WriteLine("This goes into the file");
}

// Restore the original output
Console.SetOut(oldOut);

Console.WriteLine("Machine Name: " + Environment.MachineName);
Console.WriteLine("OS Version: " + Environment.OSVersion);
Console.WriteLine("Current User: " + Environment.TickCount);

string path = Environment.GetEnvironmentVariable("PATH");
Console.WriteLine("System PATH: " + path);

// Process.Start("notepad.exe", "e:\\file.txt");
