using System;
using System.Collections.Generic;
using System.Text;

public class Foobaz
{
    private Dictionary<int, string> rule;

    public Foobaz()
    {
        //setingan awal
        rule = new Dictionary<int, string>
        {
            { 3, "foo" },
            { 4, "baz" }
        };
    }

    public void AddRule(int number, string kode)
    {
        rule.Add(number, kode);
    }

    public void PrintRule()
    {
        foreach (var item in rule)
            Console.WriteLine($"{item.Key} {item.Value}");
    }

    public void PrintNumber(int jumlahDeret)
    {
        List<string> outputList = new List<string>();

        for (int i = 1; i <= jumlahDeret; i++)
        {
            StringBuilder output = new StringBuilder();
            bool isDivisible = false;

            foreach (var item in rule)
            {
                if (i % item.Key == 0)
                {
                    output.Append(item.Value);
                    isDivisible = true;
                }
            }

            if (!isDivisible)
            {
                output.Append(i);
            }

            outputList.Add(output.ToString());
        }

        Console.WriteLine(string.Join(", ", outputList));
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Foobaz foobaz = new Foobaz();
        //tambahan
        foobaz.AddRule(5, "bar");
        foobaz.AddRule(7, "jaz");
        foobaz.AddRule(9, "huss");
        foobaz.AddRule(10, "heheheheh");
        //coba cek rule
        foobaz.PrintRule();
        foobaz.PrintNumber(180);
    }
}
