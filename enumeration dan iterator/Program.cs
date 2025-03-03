using (var enumerator = "beer".GetEnumerator())
{
    while (enumerator.MoveNext())
    {
        var element = enumerator.Current;
        Console.WriteLine(element);
    }
}

IEnumerable<int> Fibs(int fibCount)
{
    int prevFib = 0, curFib = 1;
    for (int i = 0; i < fibCount; i++)
    {
        yield return prevFib;
        int newFib = prevFib + curFib;
        prevFib = curFib;
        curFib = newFib;
    }
}

foreach (int fib in Fibs(8))
{
    Console.Write(fib + " ");
}

Console.WriteLine();

IEnumerable<string> Foo(bool breakEarly)
{
    yield return "One";
    yield return "Two";
    if (breakEarly)
        yield break;  // Exit early
    yield return "Three";
}

foreach (string s in Foo(false))
{
    Console.WriteLine(s);  // Output: One, Two
}

IEnumerable<int> EvenNumbersOnly(IEnumerable<int> sequence)
{
    foreach (int x in sequence)
    {
        if (x % 2 == 0)
            yield return x;
    }
}

foreach (int fib2 in EvenNumbersOnly(Fibs(8)))
{
    Console.Write(fib2 +  " ");  // Output: 0, 2, 8
}