public class OperationResult<T>
{
    public bool Success { get; set; }
    public T Value { get; set; }
    public string ErrorMessage { get; set; }

    public static OperationResult<T> SuccessResult(T value)
    {
        return new OperationResult<T> { Success = true, Value = value };
    }

    public static OperationResult<T> FailureResult(string errorMessage)
    {
        return new OperationResult<T> { Success = false, ErrorMessage = errorMessage };
    }
}

public class Operasi{
public OperationResult<int> TryDivide(int numerator, int denominator)
{
    if (denominator == 0)
    {
        return OperationResult<int>.FailureResult("Division by zero");
    }

    return OperationResult<int>.SuccessResult(numerator / denominator);
}
}
class Program
{
    static void Main()
    {
        Operasi operasi = new ();
        var result = operasi.TryDivide(10, 0);

        if (result.Success)
        {
            Console.WriteLine($"Division result: {result.Value}");
        }
        else
        {
            Console.WriteLine($"Error: {result.ErrorMessage}");
        }
    }
}