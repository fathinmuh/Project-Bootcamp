using System.Globalization;

public interface IFormattable
{
    string ToString(string format, IFormatProvider formatProvider);
}

internal class Program
{
    private static void Main(string[] args)
    {
        string s = true.ToString();  // s = "True"
        bool b = bool.Parse(s);      // b = true
        Console.WriteLine(s);
        Console.WriteLine(b);

        bool failure = int.TryParse("qwerty", out int i1);  // failure = false
        bool success = int.TryParse("123", out int i2);     // success = true
        double x = double.Parse("1.234", CultureInfo.InvariantCulture);  // Correctly parses as 1.234
        Console.WriteLine(failure);
        Console.WriteLine(success);
        Console.WriteLine(x);

        Console.WriteLine();
        NumberFormatInfo formatInfo = new NumberFormatInfo();
        formatInfo.CurrencySymbol = "$$";
        Console.WriteLine(3.ToString("C", formatInfo));  // $$ 3.00
        Console.WriteLine(1300.ToString("C"));
        CultureInfo uk = CultureInfo.GetCultureInfo("en-GB");
        Console.WriteLine(3.ToString("C", uk));  // £3.00 (British currency symbol)

        Console.WriteLine();
        NumberFormatInfo format = new NumberFormatInfo();
        format.NumberGroupSeparator = " ";
        Console.WriteLine(123405.6789.ToString("N1", format));  // 12 345.679
        NumberFormatInfo clonedFormat = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
        clonedFormat.NumberGroupSeparator = " ";

        Console.WriteLine();
        string formattedString = string.Format("Credit={0:C}", 500);  // Credit=$500.00
        Console.WriteLine(formattedString);
        string s2 = string.Format(CultureInfo.InvariantCulture, "{0}", 8);
        Console.WriteLine(s2);




    }
}