using System.ComponentModel;
using System.Drawing;
using System.Xml;

double d = 3.9;
int i = Convert.ToInt32(d);  // i == 4
Console.WriteLine(i);
int thirty = Convert.ToInt32("1E", 16);   // Parses "1E" in hexadecimal to 30
uint five = Convert.ToUInt32("101", 2);    // Parses "101" in binary to 5
Console.WriteLine(thirty);
Console.WriteLine(five);

object source = "42";
Type targetType = typeof(int);
object result = Convert.ChangeType(source, targetType);

Console.WriteLine(result);             // 42
Console.WriteLine(result.GetType());   // System.Int32

byte[] byteArray = new byte[] { 0, 1, 2, 3, 4 };
string base64String = Convert.ToBase64String(byteArray);
Console.WriteLine(base64String);  // Output: "AAECAwQ="
byte[] decodedBytes = Convert.FromBase64String(base64String);
Console.WriteLine(decodedBytes);

string s = XmlConvert.ToString(true);   // s = "true"
bool isTrue = XmlConvert.ToBoolean(s);  // isTrue = true
DateTime dt = DateTime.UtcNow;
string xmlDateTime = XmlConvert.ToString(dt, XmlDateTimeSerializationMode.Utc);
Console.WriteLine(xmlDateTime);  // Output: "2025-02-14T15:45:00Z"

TypeConverter colorConverter = TypeDescriptor.GetConverter(typeof(System.Drawing.Color));
Color beige = (Color)colorConverter.ConvertFromString("Beige");

byte[] byteArray2 = BitConverter.GetBytes(14.1);
foreach (byte b in byteArray2)
    Console.Write(b + " ");  // Output: 0 0 0 0 0 0 12 64


double d2 = BitConverter.ToDouble(byteArray2, 0);
Console.WriteLine(d2);  // Output: 3.5