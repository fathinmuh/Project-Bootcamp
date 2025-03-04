using System.Numerics;
using System.Security.Cryptography;

int hexValue = Convert.ToInt32("1E", 16);  // Parses "1E" as hexadecimal, gives 30

int i;
bool ok = int.TryParse("3", out i);  // Tries to parse "3" as an integer, ok will be true
string hexString = 46.ToString("X");  // Hexadecimal representation: "2D"
Console.WriteLine(hexString);
int i2 = 23;
double d = i2;  // Implicit conversion from int to double
Console.WriteLine(d);
double d2 = 23.5;
int i3 = (int) d2;  // Explicit conversion truncates the decimal part
Console.WriteLine(i3);
double d3 = 23.501;
int i4 = Convert.ToInt32(d3);  // i == 24 (rounded)
Console.WriteLine(i4);

double value = 2.5;
Console.WriteLine(Math.Round(value));  // 2 (default rounding)
Console.WriteLine(Math.Floor(value));  // 2 (rounds down)
Console.WriteLine(Math.Ceiling(value)); // 3 (rounds up)
Console.WriteLine(Math.Max(3, 5));  // 5
Console.WriteLine(Math.Min(3, 5));  // 3

Console.WriteLine(Math.Abs(-10));  // 10
Console.WriteLine(Math.Sqrt(16));  // 4
Console.WriteLine(Math.Pow(2, 0)); // 8
Console.WriteLine(Math.Log(2, 3)); // 2 (logarithm base 10)



Complex c1 = new Complex(2, 3.5);  // Real part: 2, Imaginary part: 3.5
Complex c2 = new Complex(3, 0);    // Real part: 3, Imaginary part: 0

Console.WriteLine(c1 + c2);  // Output: (5, 3.5)
Console.WriteLine(c1 * c2);  // Output: (6, 10.5)
Console.WriteLine(c1.Magnitude);  // Magnitude: 4.03112887414927
Console.WriteLine(c1.Phase);      // Phase: 1.05165021254837

Random random = new Random();
Console.WriteLine(random.Next(100));  // Generates a random number between 0 and 99
Console.WriteLine(random.NextDouble());  // Generates a random double between 0 and 1
Console.WriteLine(random.Next(100));  // Random output

RandomNumberGenerator rand = RandomNumberGenerator.Create();
byte[] bytes = new byte[32];
rand.GetBytes(bytes);  // Fills byte array with cryptographically strong random bytes
// Console.WriteLine(bytes);
Console.WriteLine(BitConverter.ToString(bytes));

int number = 16;
Console.WriteLine(BitOperations.IsPow2(number));  // True, because 16 is a power of 2
// Console.WriteLine(BitOperations.LeadingZeroCount(number));  // Number of leading zeros in binary