using System.Collections;

var words = new List<string>();  // Create an empty list of strings
words.Add("melon");
words.Add("avocado");
words.AddRange(new[] { "banana", "plum" });  // Add a range of words

words.Insert(0, "lemon");  // Insert at the start
words.Remove("melon");     // Remove by value
words.RemoveAt(3);         // Remove by index


// Output first and last elements
// Console.WriteLine(words[0]);
// Console.WriteLine(words[words.Count - 1]);

words.Add("labu");
words.Add("naga");
words.RemoveAll(s => s.StartsWith("n"));  // Remove based on a condition
foreach (string fruit in words)
{
    Console.WriteLine(fruit);
}

string[] wordsArray = words.ToArray();
ArrayList al = new ArrayList();
al.Add("hello");
al.Add(42);  // Adds an integer

string first = (string)al[0]; 
foreach (var isial in al)
    Console.WriteLine(isial);

var tune = new LinkedList<string>();
tune.AddFirst("do");   // Add to the start
tune.AddLast("so");    // Add to the end
tune.AddAfter(tune.First, "re");   // Add after 'do'
tune.AddBefore(tune.Last, "fa");  // Add before 'so'

// // Removing elements
// tune.RemoveFirst();    // Removes 'do'
// tune.RemoveLast();     // Removes 'so'

// Finding and removing a specific node
// LinkedListNode<string> miNode = tune.Find("mi");
// tune.Remove(miNode);

// Iterate through the linked list
foreach (var note in tune)
{
    Console.WriteLine(note);
}

var q = new Queue<int>();
q.Enqueue(10);  // Add 10 to the queue
q.Enqueue(20);  // Add 20 to the queue
q.Enqueue(30);

Console.WriteLine(q.Count);  // Output: 2
Console.WriteLine(q.Peek()); // Output: 10

Console.WriteLine(q.Dequeue());  // Output: 10 (removes it from the queue)
Console.WriteLine(q.Dequeue()); 
Console.WriteLine(q.Dequeue()); 

Console.WriteLine();
var s = new Stack<int>();
s.Push(1);  // Add 1 to the stack
s.Push(2);  // Add 2 to the stack
s.Push(3);  // Add 3 to the stack

Console.WriteLine(s.Count);  // Output: 3
Console.WriteLine(s.Peek()); // Output: 3

Console.WriteLine(s.Pop());  // Output: 3 (removes it from the stack)
Console.WriteLine(s.Pop());  // Output: 2
Console.WriteLine(s.Pop());

Console.WriteLine();
var letters = new HashSet<char>("the quick brown fox");
Console.WriteLine(letters.Contains('t'));  // Output: true
Console.WriteLine(letters.Contains('j'));  // Output: false
foreach (char c in letters)
    Console.Write(c);  // Output: the quickbrownfx

Console.WriteLine();
// Set operations
letters.IntersectWith("aeiou");
foreach (char c in letters)
    Console.Write(c);  // Output: euio

Console.WriteLine();
var set = new SortedSet<int> { 1, 3, 5, 7, 9 };
set.Add(2);  // Adds 2 in sorted order
foreach (var num in set)
{
    Console.Write(num);  // Output: 1 2 3 5 7 9
}

Console.WriteLine();
BitArray bits = new BitArray(4);

// Set individual bits
bits[0] = true;
bits[1] = false;
bits[2] = true;
bits[3] = false;

// Print the bits
for (int i = 0; i < bits.Count; i++)
{
    Console.Write(bits[i] ? "1" : "0");  // Outputs 1010
}