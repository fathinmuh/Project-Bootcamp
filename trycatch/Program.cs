

class Program{
    static void Main()    {
    bool TryDivide(int numerator, int denominator, out int result){
        if (denominator == 0){
            result = 0;
            return false;  // Return false if division by zero
        }

        result = numerator / denominator;
        return true;
    }



        int result;
        bool success = TryDivide(10, 0, out result);

        if (success)
        {
            Console.WriteLine($"Division result: {result}");
        }
        else
        {
            Console.WriteLine("Division by zero occurred.");
        }
    }
}