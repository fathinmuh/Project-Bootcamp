using System.Text;

StringBuilder[] builders = new StringBuilder[5];
builders[0] = new StringBuilder("builder1");
builders[1] = new StringBuilder("builder2");
builders[2] = new StringBuilder("builder3");

long[] numbers = new long[3];
numbers[0] = 12345;
numbers[1] = 54321;

Console.WriteLine(builders[1]);
Console.WriteLine(numbers[0]);

StringBuilder[] shallowClone = (StringBuilder[]) builders.Clone();
Console.WriteLine(shallowClone[1]);

int[] numbers2 = { 1, 2, 3, 4, 9 };
Array.Resize(ref numbers2, 5); 
int first = numbers2[0];  // Accessing the first element
int last = numbers2[numbers2.Length - 1];  // Accessing the last element
Console.WriteLine(last);

Array a = Array.CreateInstance(typeof(int), 3); // Creates an array with 3 elements
a.SetValue(10, 0);  // Set the first element to 10
a.SetValue(20, 1);  // Set the second element to 20
int value = (int)a.GetValue(0);  // Get the first element, which is 10
Console.WriteLine(value);

int[,] matrix = new int[2, 2];
matrix[0, 0] = 1;
matrix[0, 1] = 2;
matrix[1, 0] = 3;
matrix[1, 1] = 4;

Console.WriteLine();  // Output: 2
int[] numbers3 = { 4, 2, 1, 14, 5 };
int index = Array.BinarySearch(numbers3, 14);  // Searches for the value 3
Console.WriteLine(index);  // Output: 2
Array.Sort(numbers3);
int index2 = Array.BinarySearch(numbers3, 14);  // Searches for the value 3
Console.WriteLine(index2);  // Output: 2

Console.WriteLine();
int[] numbers4 = { 1, 2, 3 };
foreach (int number in numbers4)
{
    Console.WriteLine(number);
}

Array.ForEach(new[] { 4, 2, 3 }, Console.WriteLine);