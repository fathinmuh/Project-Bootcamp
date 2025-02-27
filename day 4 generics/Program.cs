﻿using System.Numerics;

class Calculator
{
	public T Add<T>(T a, T b)  where T : INumber<T> 
    {
		return a + b;
	}

	public T Minus<T>(T a, T b)  where T : ISubtractionOperators<T, T, T> 
    {
		return a - b;
	}

    public T Multi<T>(T a, T b)  where T : IMultiplyOperators<T, T, T> 
    {
		return a * b;
	}

    public T Devide<T>(T a, T b)  where T : IDivisionOperators<T, T, T> 
    {
		return a / b;
	}

}
class Program {
	static void Main() {
		Calculator calc = new();
        Console.WriteLine(calc.Add<int>(3,4));
        Console.WriteLine(calc.Devide<decimal>(3,4));
	}	
}