
public delegate void Foobarjazz(int i);
public class DeretBilangan
{
    public event Foobarjazz Fbj;
    public void PrintNumbers(int n)    {
        for (int i = 1; i <= n; i++)
        {
            if (i % 3 == 0 || i % 5 == 0 || i % 7 == 0){
                Kelipatan357(i);
            } else
            Console.Write(i + " ");
        }
    }

    public void Kelipatan357(int i){ //trigger
        Fbj?.Invoke(i);
    }
}

public class Kelipatan{
    public void Tiga(int i){
        if (i % 3 == 0) Console.Write("Foo");
    }
    public void Lima(int i){
        if (i % 5 == 0) Console.Write("Bar");
    }
    public void Tujuh(int i){
        if (i % 7 == 0) Console.Write("Jazz");
    }
    public void Spasi(int i){
        Console.Write(" ");
    }
}

class Program{
    static void Main(){
        DeretBilangan deretBilangan = new();
        Kelipatan kelipatan = new ();
        string x = Console.ReadLine();
        int y = int.Parse(x);

        deretBilangan.Fbj += kelipatan.Tiga;
        deretBilangan.Fbj += kelipatan.Lima;
        deretBilangan.Fbj += kelipatan.Tujuh;
        deretBilangan.Fbj += kelipatan.Spasi;

        deretBilangan.PrintNumbers(y);
    }
}