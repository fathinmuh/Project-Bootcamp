public class Panda
{
    public string Name;
    public override string ToString() => Name;
}

class program{
    static void Main(){
        Panda p = new Panda { Name = "Petey" };
        Console.WriteLine(p);
    }
}
