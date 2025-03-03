public struct Note
{
    int value;

    public Note(int semitonesFromA)
    {
        value = semitonesFromA;
    }

    // Overload the + operator to add an integer (semitones) to a Note
    public static Note operator + (Note x, int semitones)
    {
        return new Note(x.value + semitones);
    }
}

class Program{
    static void Main(){
        Note B = new Note(2);    // Note B, 2 semitones from A
        Note CSharp = B + 2;     // Adds 2 semitones to B, resulting in C#
    }
}