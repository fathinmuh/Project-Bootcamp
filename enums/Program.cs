using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        int x = 5, y = 3;
        
        // Using Debug for debug builds
        Debug.Write("Data");
        Debug.WriteLine(23 * 34);
        Debug.WriteIf(x > y, "x is greater than y");

        // Using Trace for both debug and release builds
        Trace.Write("Data");
        Trace.WriteLine(23 * 34);
        Trace.WriteIf(x > y, "x is greater than y");
        
        Trace.TraceInformation("This is an informational message.");
        Trace.TraceWarning("This is a warning.");
        Trace.TraceError("This is an error.");
    }
}