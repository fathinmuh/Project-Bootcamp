using SingletonPattern;

internal class Program
{
    private static void Main(string[] args)
    {
        // The client code.
        Console.WriteLine("Sebelum menerapkan singleton");
        Regular regular1 = new Regular();
        Regular regular2 = new Regular();

        regular1.ShowMessage();
        regular2.ShowMessage();
        if (regular1 == regular2)
        {
            Console.WriteLine("Singleton works, both variables contain the same instance.\n");
        }
        else
        {
            Console.WriteLine("Singleton failed, variables contain different instances.\n");
        }

        Console.WriteLine("Setelah menerapkan singleton");
        Singleton s1 = Singleton.GetInstance();
        Singleton s2 = Singleton.GetInstance();

        if (s1 == s2)
        {
            Console.WriteLine("Singleton works, both variables contain the same instance.");
        }
        else
        {
            Console.WriteLine("Singleton failed, variables contain different instances.");
        }
    }
}