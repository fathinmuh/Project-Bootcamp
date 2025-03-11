public interface ICard{
    int Id{get;}
    int FirstFaceValue{get;}
    int SecondFaceValue{get;}
}

public class Card : ICard
{
    public int Id { get; }
    public int FirstFaceValue { get; }
    public int SecondFaceValue { get; }
    public Card(int id, int first, int second)
    {
        Id = id;
        FirstFaceValue = first;
        SecondFaceValue = second;
    }

    public override string ToString()
    {
        return $"[{FirstFaceValue}|{SecondFaceValue}]";
    }
}

public interface IDeck{
    void shuffle();
    Card DrawCard();
}

public class Deck:IDeck{
    public List<Card> Cards { get; private set; }
    public Deck()
    {
        Cards = new List<Card>();
        int id = 1;

        for (int i = 0; i <= 6; i++)
        {
            for (int j = i; j <= 6; j++)
            {
                Cards.Add(new Card(id++, i, j));
            }
        }
    }

    public void shuffle(){
        Random rng = new Random();
        int n = Cards.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1);
            (Cards[i], Cards[j]) = (Cards[j], Cards[i]); // Swap kartu
        }

    }
    public Card DrawCard()
    {
        if (Cards.Count == 0) throw new InvalidOperationException("Deck kosong!");
        
        Card drawnCard = Cards[0];
        Cards.RemoveAt(0);
        return drawnCard;
    }
}

public interface IPlayer{
    int Id{get;}
    string Name{get;}
}
public class Player:IPlayer{
    public int Id{get;}
    public string Name{get;}
    public Player(int id, string name){
        Id = id;
        Name = name;
    }
    public override string ToString()
    {
        return Name;
    }
}

// public interface IBoard{

// }

// public class Board:Card,IBoard{

// }
public class GameController{
    private IDeck deck;
    private List<IPlayer> players;
    private Dictionary<IPlayer,List<Card>> hand;
    private Dictionary<int, Card> moveOptions;
    private IPlayer currentPlayer;
    private int maxPlayer;

    public GameController(IDeck deck)
    {
        this.deck = deck;
        this.deck.Shuffle();
        players = new List<IPlayer>();
        hand = new Dictionary<IPlayer, List<Card>>();
    }


}

internal class Program
{
    private static void Main(string[] args)
    {
        Deck deck = new();
        deck.shuffle();
        Console.WriteLine($"\nMengambil kartu: {deck.DrawCard()}{deck.DrawCard()}{deck.DrawCard()}{deck.DrawCard()}");
        Console.WriteLine($"Sisa kartu di deck: {deck.Cards.Count}");
    }
}