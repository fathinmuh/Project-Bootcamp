class Program{
    static void Main(){
        int? x = 5;
        int? y = 10;
        bool V = (x.HasValue && y.HasValue) ? (x.Value < y.Value) : false;
        Console.WriteLine(V);

        Console.WriteLine("x==5 " +(x==5));
        Console.WriteLine("x+y=" +(x+y));

        if (x.HasValue)
        {
            int z = (int)x;
            Console.WriteLine(z);
        }
        
        object o = x;
        Console.WriteLine("nilai o = " +o);

        int? x1 = null;
        int y1 = x1 ?? 8;  // If x is null, y will be 5
        Console.WriteLine("kalau x1 null y1=8; " +y1);  // Output: 5

        int? a = null, b = 1, c = 2;
        Console.WriteLine(a ?? b ?? c);  // Output: 1 (first non-null value)
    }
}