public delegate void FooBarJazz(int i);
public class PrintNumber{
    public event FooBarJazz Fbj;
    public void Kelipatan357(int i){ //trigger
        Fbj?.Invoke(i);
    }

    public IEnumerable<int> Fibs(int lengthNumber)
    {
        int x = 0, y = 1;
        for (int i = 0; i < lengthNumber; i++)
        {
            int newNumber = x + y;
            x = newNumber;

            if (x % 3 == 0 || x % 5 == 0 || x % 7 == 0 || x % 9 == 0){
                Kelipatan357(x);
            }
            else yield return x;
        }
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
    public void Sembilan(int i){
        if (i % 9 == 0) Console.Write("Huzz");
    }
    public void Spasi(int i){
        Console.Write(" ");
    }
}

// class Program{
//     static void Main(){
//         PrintNumber printNumber = new();
//         Kelipatan kelipatan = new ();

//         string n = Console.ReadLine();
//         int x= int.Parse(n);

//         printNumber.Fbj += kelipatan.Tiga;
//         printNumber.Fbj += kelipatan.Lima;
//         printNumber.Fbj += kelipatan.Tujuh;
//         printNumber.Fbj += kelipatan.Sembilan;
//         printNumber.Fbj += kelipatan.Spasi;

//         foreach (int fib in printNumber.Fibs(x)){
//             Console.Write(fib + " ");
//         }
//     }
// }







