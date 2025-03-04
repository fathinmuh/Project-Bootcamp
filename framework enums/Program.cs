[Flags]
public enum BorderSides { Left = 1, Right = 2, Top = 4, Bottom = 8, LeftRight = Left | Right }



class Program{
    static void Main(){

        static int GetIntegralValue(Enum anyEnum){
            return (int) (object) anyEnum;
        }
        Console.WriteLine(GetIntegralValue(BorderSides.Top)); // Output: 4
        int i = (int) BorderSides.Top; // i == 4
        Console.WriteLine(i);  // Output: 4

        static object GetBoxedIntegralValue(Enum anyEnum){
            Type integralType = Enum.GetUnderlyingType(anyEnum.GetType());
            return Convert.ChangeType(anyEnum, integralType);
        }

        object result = GetBoxedIntegralValue(BorderSides.Top);
        Console.WriteLine(result);  // Output: 4
        Console.WriteLine(result.GetType());  // Output: System.Int32

        BorderSides side = BorderSides.Top;
        Console.WriteLine(side.ToString());  // Output: Top
        Console.WriteLine(side.ToString("D"));  // Output: 4 (underlying value)
        Console.WriteLine(side.ToString("X"));  // Output: 4 (hexadecimal)

        BorderSides sides = BorderSides.Left | BorderSides.Right;
        Console.WriteLine(sides.ToString("F"));  // Output: Left, Right

        object bs = Enum.ToObject(typeof(BorderSides), 3);
        Console.WriteLine(bs);  // Output: Left, Right
        BorderSides side2 = (BorderSides) 4;
        Console.WriteLine(side2);  // Output: Left, Right

        BorderSides side3 = (BorderSides) Enum.Parse(typeof(BorderSides), "Top");
        Console.WriteLine(side3);

        BorderSides sides4 = (BorderSides) Enum.Parse(typeof(BorderSides), "Left, Right");
        Console.WriteLine(sides4);  

        bool success = Enum.TryParse("Top", out BorderSides side4);
        Console.WriteLine(success ? side.ToString() : "Parsing failed");  // Output: Top


        Console.WriteLine();
        foreach (Enum value in Enum.GetValues(typeof(BorderSides)))
            Console.WriteLine(value);

        foreach (string name in Enum.GetNames(typeof(BorderSides)))
            Console.WriteLine(name);

        Console.WriteLine();
        BorderSides sides5 = BorderSides.Left | BorderSides.Bottom;
        Console.WriteLine(sides5);  // Output: Left, Bot

        BorderSides b = BorderSides.LeftRight;
        b += 1234;  // No error, but the result is likely incorrect
        Console.WriteLine(b);

        

    }
}