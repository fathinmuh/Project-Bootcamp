class Program{
    static void Main(){
        int? x = 5;
        int? y = 10;
        bool b = (x.HasValue && y.HasValue) ? (x.Value < y.Value) : false;
        Console.WriteLine(b);

        Console.WriteLine(x==5);
        Console.WriteLine(x+y);
    }
}