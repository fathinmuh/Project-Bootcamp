// See https://aka.ms/new-console-template for more information
Console.WriteLine("n=");
string n = Console.ReadLine();
Console.WriteLine("n=" + n);
int x= int.Parse(n);


for (int i = 1; i < x; i++)
{
    if (((i % 3) == 0)&&((i % 5)==0 )){
    Console.Write("foobar, ");
    }
    else if ((i % 3) == 0){
    Console.Write("foo, ");
    }
    else if ((i % 5) == 0){
    Console.Write("bar, ");
    }
    else Console.Write(i+", ");
}



