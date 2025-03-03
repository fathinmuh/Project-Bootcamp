// See https://aka.ms/new-console-template for more information
string n = Console.ReadLine();
int x= int.Parse(n);


for (int i = 1; i < x; i++)
{
    if (((i % 7) == 0)&&((i % 5) == 0)&&((i % 3)==0 )){
    Console.Write("foobarjazz, ");
    }
    if (((i % 7) == 0)&&((i % 5)==0 )){
    Console.Write("barjazz, ");
    }
    if (((i % 7) == 0)&&((i % 3)==0 )){
    Console.Write("foojazz, ");
    }
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



