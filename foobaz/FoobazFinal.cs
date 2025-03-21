public class Foobaz
{
    public string? kode;
    public int iber;
    private Dictionary<int, string>? rule = new Dictionary<int, string>{
            {3, "foo"},
            {4, "baz"},
    };

    public void addRule(int iber, string kode)
    {
        rule.Add(iber, kode);
    }

    public void PrintRule()
    {
        foreach (var item in rule)
            Console.WriteLine($"{item.Key} {item.Value}");
    }

    public void PrintNumber()
    {

        for (int i = 1; i <= 10; i++)
        {
            foreach (int item in rule.Keys)
            {
                bool couldBeDevided = false;
                if (i % item == 0)
                {
                    Console.Write(rule[item]);

                }

                else Console.Write(i);

            }
        }
    }

}

public class Program
{
    public static void Main(string[] args)
    {
        Foobaz foobaz = new();
        // foobaz.addRule(1,"a");
        foobaz.PrintRule();
        foobaz.PrintNumber();
    }
}