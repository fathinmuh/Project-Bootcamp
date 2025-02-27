﻿using System.Numerics;
public interface ICalculator<T>
{
    public T Add(T a, T b);
    public T Minus(T a, T b);
    public T Multi(T a, T b);
    public T Devide(T a, T b);
}
public class Calculator<T> : ICalculator<T> where T : INumber<T>
{
    public T Add(T a, T b) => a + b;
    public T Minus(T a, T b) => a - b;
    public T Multi(T a, T b) => a * b;

    public T Devide(T a, T b)
    {
        if (b.Equals(default(T)))
            throw new DivideByZeroException("Pembagian dengan nol tidak diperbolehkan!");
        return a / b;
    }
}
class Program {
	static void Main() {
		ICalculator<int> calc = new Calculator<int>();
        Console.WriteLine(calc.Add(5,8));

        ICalculator<decimal> calcdecimal = new Calculator<decimal>();
        Console.WriteLine(calcdecimal.Devide(5,8));
	}	
}