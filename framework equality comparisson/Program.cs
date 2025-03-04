class Foo { public int X; }

internal class Program
{
    private static void Main(string[] args)
    {
        int x = 5, y = 5;
        Console.WriteLine(x == y);

        var dt1 = new DateTimeOffset(2010, 1, 1, 1, 1, 1, TimeSpan.FromHours(8));
        var dt2 = new DateTimeOffset(2010, 1, 1, 2, 1, 1, TimeSpan.FromHours(9));
        Console.WriteLine(dt1 == dt2); // True, because they represent the same moment in time.

        
        Foo f1 = new Foo { X = 5 };
        Foo f2 = new Foo { X = 5 };
        Console.WriteLine(f1 == f2); 
        Foo f3 = f1;
        Console.WriteLine(f1 == f3);


        Uri uri1 = new Uri("http://www.linqpad.net");
        Uri uri2 = new Uri("http://www.linqpad.net");
        Console.WriteLine(uri1 == uri2); 

        string s1 = "http://www.linqpad.net";
        string s2 = "http://" + "www.linqpad.net";
        Console.WriteLine(s1 == s2); // True, because strings are compared by value.

        object x1 = 5;
        object y1 = 5;
        Console.WriteLine(x1 == y1);
        Console.WriteLine(x.Equals(y));

        object x2 = 3, y2 = 3;
        Console.WriteLine(object.Equals(x2, y2)); // True

        x2 = null;
        Console.WriteLine(object.Equals(x2, y2)); // False

        y2 = null;
        Console.WriteLine(object.Equals(x2, y2)); // True
    }
}