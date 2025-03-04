using System.Text;

char c = 'a';  // A character
char newLine = '\n';  // A newline character
char b = '@';
Console.WriteLine(char.ToUpper(c));  // C
Console.WriteLine(char.IsWhiteSpace(newLine));  // True
Console.WriteLine(char.ToUpperInvariant('i'));  // I
Console.WriteLine(char.IsLetter('A'));  // True
Console.WriteLine(char.IsDigit('5'));  // True
Console.WriteLine(char.IsWhiteSpace('\t'));  // True
Console.WriteLine(char.GetUnicodeCategory(b));  // UppercaseLetter

string s1 = "Hello";
string s2 = "First Line\r\nSecond Line";  // Multiline string
Console.WriteLine();
Console.Write(new string('*', 10));  // **********

char[] ca = "Hello".ToCharArray();
string s = new string(ca);  // s = "Hello"
Console.WriteLine();
Console.WriteLine(ca);

string empty = "";
Console.WriteLine();
Console.WriteLine(empty == "");  // True
Console.WriteLine(empty == string.Empty);  // True
Console.WriteLine(empty.Length == 0);  // True

string nullString = null;
Console.WriteLine();
Console.WriteLine(nullString == null);  // True
Console.WriteLine(nullString == "");  // False

string nullOrEmptyString = null;
Console.WriteLine();
Console.WriteLine(string.IsNullOrEmpty(nullOrEmptyString));

string str = "abcde";
char letter = str[1];  // letter == 'b'
Console.WriteLine();
Console.WriteLine(letter);
foreach (char a in "123")
    Console.Write(a + ",");  // 1,2,3,
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("quick brown fox".EndsWith("fox"));  // True
Console.WriteLine("quick brown fox".Contains("brown"));  // True
Console.WriteLine("quick brown fox".Contains("fathin"));  // 
Console.WriteLine("abcde".IndexOf("f"));  // 2
Console.Write("ab,cd ea".IndexOfAny(new char[] { 'e', ',' }));  // 2
Console.WriteLine();

Console.WriteLine();
string left3 = "12345".Substring(0, 3);  // left3 = "123"
Console.WriteLine(left3);
string s3 = "helloworld".Insert(5, ", ");  // s1 = "hello, world"
string s4 = s3.Remove(5, 4);  // s2 = "helloworld"
Console.WriteLine(s3);
Console.WriteLine(s4);
Console.WriteLine("12345".PadRight(9, '*'));  // ****12345
Console.WriteLine("  abc \t\r\n aaaaaaaaaaa ".Trim().Length);  // 3
Console.WriteLine("to be done".Replace(" ", " | "));  // to | be | done

Console.WriteLine();
string[] words = "The quick brown fox".Split();
foreach (string word in words)
    Console.Write(word + "|");  // The|quick|brown|fox|
Console.WriteLine();
string[] words2 = "The quick brown fox".Split();
string together = string.Join(" ", words2);  // The quick brown fox
Console.WriteLine(together);

Console.WriteLine();
string s5 = $"It's hot this {DateTime.Now.DayOfWeek} morning";
Console.WriteLine(s5);
string composite = "It's {0} degrees in {1} on this {2} morning";
string s6 = string.Format(composite, 35, "Mrican", DateTime.Now.DayOfWeek);
Console.WriteLine(s6);

Console.WriteLine();
Console.WriteLine(string.Equals("foo", "FOO", StringComparison.OrdinalIgnoreCase));  // True
Console.WriteLine(string.Equals("foo", "FOO", StringComparison.Ordinal));  // True
Console.WriteLine("Boston".CompareTo("tin"));  // 1
Console.WriteLine("Boston".CompareTo("Boston"));  // 0
Console.WriteLine("Boston".CompareTo("Chicago"));  // -1

Console.WriteLine();
StringBuilder sb = new StringBuilder();
for (int i = 0; i < 50; i++) sb.Append(i).Append(",");
Console.WriteLine(sb.ToString());

Console.WriteLine();
string text = "Hello, World!";
byte[] utf8Bytes = Encoding.UTF8.GetBytes(text);
string decodedText = Encoding.UTF8.GetString(utf8Bytes);
Console.WriteLine(utf8Bytes);