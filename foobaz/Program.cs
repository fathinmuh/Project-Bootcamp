
// public delegate foobarjazz();
public class DeretBilangan
{
    // public void event Foo;
    public void PrintNumbers(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            Console.Write(i + " ");
        }
    }
}

public class Kelipatan{
    public void Kelipatan7()
    {
        Console.Write("Jazz ");
    }

    public void Kelipatan5()
    {
        Console.Write("Bar ");
    }

    public void Kelipatan3()
    {
        Console.Write("Jaz ");
    }
}


class Program{
    static void Main(){
        DeretBilangan deretBilangan = new();
        string x = Console.ReadLine();
        int y = int.Parse(x);
        deretBilangan.PrintNumbers(y);
    }
}