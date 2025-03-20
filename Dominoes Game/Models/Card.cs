namespace dominoesGame;

public class Card : ICard
{
    public int Id { get; }
    public int FirstFaceValue { get; set;}
    public int SecondFaceValue { get; set;}
    public Card(int id, int first, int second)
    {
        Id = id;
        FirstFaceValue = first;
        SecondFaceValue = second;
    }

    public bool IsDouble()
    {
        return FirstFaceValue == SecondFaceValue;
    }

    public int GetHighestValue()
    {
        return Math.Max(FirstFaceValue, SecondFaceValue);
    }

    public override string ToString()
    {
        return $"[{FirstFaceValue}|{SecondFaceValue}]";
    }
}
