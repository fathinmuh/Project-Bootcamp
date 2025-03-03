// See https://aka.ms/new-console-template for more information
IEnumerable<int> Fibs(int fibCount)
{
    int prevFib = 1, curFib = 1;
    for (int i = 0; i <= fibCount; i++)
    {
        yield return prevFib;
        int newFib = prevFib + curFib;
        prevFib = newFib;
        // curFib = newFib;
    }
}

string n = Console.ReadLine();
int x= int.Parse(n);


foreach (int fib in Fibs(x))
{
    Console.Write(fib + " ");
}

// for (int i = 1; i < x; i++)
// {
//     if (((i % 3) == 0)&&((i % 5)==0 )){
//     Console.Write("foobar, ");
//     }
//     else if ((i % 3) == 0){
//     Console.Write("foo, ");
//     }
//     else if ((i % 5) == 0){
//     Console.Write("bar, ");
//     }
//     else Console.Write(i+", ");
// }


