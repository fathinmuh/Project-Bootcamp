public interface IDeck{
    void Shuffle();
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

    public void Shuffle(){
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
public interface IPlayer{
    int Id{get;}
    string Name{get;}
    // bool IsBot{get;}
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

public interface IBoard{
    void UpdateBoard(Card card, IPlayer player, bool posisi);
    List<Card> GetBoard();
}

public class Board:Card,IBoard{
    private List<Card> playedCards;
    public void UpdateBoard(Card card, IPlayer player, bool posisi){
        if(posisi){
            playedCards.Add(card);
        }
        else {
            playedCards.Insert(0, card);
        }
    }
    public List<Card> GetBoard(){
        return playedCards;
    }
    public Board(int id, int first, int second) : base(id, first, second)
    {
        playedCards = new List<Card>();
    }
}

public class GameController{
    private IDeck deck;
    private IBoard board;
    private List<IPlayer> players;
    private Dictionary<IPlayer,List<Card>> hand;
    private Dictionary<int, Card> moveOptions;
    private IPlayer currentPlayer;
    private int currentPlayerIndex=0;
    Action<IPlayer> onPlayerTurn;

    public GameController(IDeck deck)
    {
        this.deck = deck;
        this.deck.Shuffle();
        players = new List<IPlayer>();
        hand = new Dictionary<IPlayer, List<Card>>();
        board=new Board(0,0,0);
    }
    public void AssignPlayers(List<IPlayer> playerList)
    {
        players.AddRange(playerList);
        foreach (var player in players)
        {
            hand[player] = new List<Card>();
        }
    }

    public void DealCards(int cardsPerPlayer)
    {
        foreach (var player in players)
        {
            for (int i = 0; i < cardsPerPlayer; i++)
            {
                if (deck == null) break;
                hand[player].Add(deck.DrawCard());
            }
        }
    }

    public void PlayCard(IPlayer player, Card card, bool posisi)
    {
        hand[player].Remove(card);
        board.UpdateBoard(card,player,posisi);
        Display.ShowBoard(board.GetBoard());
    }

    public Dictionary<IPlayer, List<Card>> GetHands()
    {
        return hand;
    }

    public IPlayer DetermineFirstPlayer()
    {
        var highestDouble = players
            .SelectMany(p => hand[p], (player, card) => new { player, card })
            .Where(x => x.card.IsDouble())
            .OrderByDescending(x => x.card.GetHighestValue())
            .FirstOrDefault();

        return highestDouble?.player;
    }

    public void RandomizeTurnOrder(IPlayer currentPlayer)
    {
        if (players.Count > 1)
        {
            players = players.Where(p => p != currentPlayer).OrderBy(_ => Guid.NewGuid()).ToList();
            players.Insert(0, currentPlayer);
        }

    }
    public void NextTurn (Action<IPlayer> onPlayerTurn){
        if (players.Any())
        {
            currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
            currentPlayer = players[currentPlayerIndex];
            onPlayerTurn(currentPlayer);
        }
    }
    public Dictionary<int, Card> GetPlayableMoves(IPlayer player)
    {
        List<Card> boardCards = board.GetBoard();
        // if (boardCards.Count == 0) return hand[player].ToDictionary(c => c.Id, c => c);
        Dictionary<int, Card> moveOptions = new Dictionary<int, Card>(); // Reset tiap kali method dipanggil
        int leftValue = boardCards.First().FirstFaceValue;
        int rightValue = boardCards.Last().SecondFaceValue;

        foreach (Card card in hand[player])
        {
            if (card.FirstFaceValue == leftValue || card.SecondFaceValue == leftValue ||
                card.FirstFaceValue == rightValue || card.SecondFaceValue == rightValue)
            {
                moveOptions[card.Id] = card;
            }
        }
        return moveOptions;
        
    }
   
   

    public void CheckNumber(){
        List<Card> boardCards = board.GetBoard();
        int leftValue = boardCards.First().FirstFaceValue;
        int rightValue = boardCards.Last().SecondFaceValue;
        Console.WriteLine(leftValue);
        Console.WriteLine(rightValue);
        Console.WriteLine("Board saat ini: " + string.Join(", ", boardCards.Select(c => $"(ID: {c.Id}) {c}")));
    }
 

}

public static class Display
{
    private static int boardCursorTop;
    public static void ShowBoard(List<Card> playedCards)
    {
        for (int i = 0; i < Console.WindowHeight; i++)
        {
            Console.SetCursorPosition(0, boardCursorTop + i);
            Console.Write(new string(' ', Console.WindowWidth));
        }
        Console.SetCursorPosition(0, 0);
        Console.WriteLine("Board saat ini:");
        Console.WriteLine(string.Join(" ", playedCards));
    }
    public static int SetupPlayers()
    {
        Console.Write("Masukkan jumlah pemain (2-4): ");
        int numPlayers;
        int maxPlayer = 4;
        while (!int.TryParse(Console.ReadLine(), out numPlayers) || numPlayers < 2 || numPlayers > maxPlayer)
        {
            Console.Write("Input tidak valid! Masukkan jumlah pemain antara 2-4: ");
        }
        return numPlayers;
    }

    public static string GetPlayerName(int playerNumber)
    {
        Console.Write($"Masukkan nama untuk Pemain {playerNumber}: ");
        return Console.ReadLine();
    }

    public static void ShowCurrentPlayer(IPlayer currentPlayer)
    {
        Console.WriteLine(currentPlayer != null ? $"{currentPlayer.Name} mulai duluan!" : "Tidak ada yang punya kartu double, pilih pemain pertama secara acak.");
    }
    public static Card ShowHands(IPlayer player, List<Card> playerHand, Dictionary<int, Card> moveOptions)
    {
        Console.WriteLine();
        Console.WriteLine($"{player.Name}, pilih kartu yang akan dimainkan:");
        for (int i = 0; i < playerHand.Count; i++)
        {
            Card card = playerHand[i];
            bool isPlayable = moveOptions.ContainsKey(card.Id);

            // Ubah warna teks jika kartu bisa dimainkan
            if (isPlayable)
                Console.ForegroundColor = ConsoleColor.Green; // Warna hijau untuk kartu yang bisa dimainkan
            else
                Console.ForegroundColor = ConsoleColor.Gray;  // Warna abu-abu untuk kartu yang tidak bisa dimainkan

            Console.Write($"{i + 1}.{card}  ");
        }
        Console.ResetColor();
        Console.WriteLine();
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > playerHand.Count)
        {
            Console.WriteLine("Pilihan tidak valid, coba lagi.");
        }

        return playerHand[choice - 1];
    }    
    public static bool PlacementSide(){
        Console.WriteLine("KIRI atau KANAN");
        while(true){
            string input=Console.ReadLine();
            if (input == "KIRI") return false;
            if (input == "KANAN") return true;
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Deck deck = new Deck();
        GameController gameController = new GameController(deck);

        int numPlayers = Display.SetupPlayers();

        var players = new List<IPlayer>();
        for (int i = 1; i <= numPlayers; i++)
        {
            string playerName = Display.GetPlayerName(i);
            players.Add(new Player(i, playerName));
        }

        gameController.AssignPlayers(players);
        gameController.DealCards(5);

        var currentPlayer = gameController.DetermineFirstPlayer();
        Display.ShowCurrentPlayer(currentPlayer);
        gameController.RandomizeTurnOrder(currentPlayer);

        // Pemain pertama memainkan kartu
        if (currentPlayer != null)
        {
            Dictionary<int, Card> moveOptions=gameController.GetPlayableMoves(currentPlayer);
            var playerHand = gameController.GetHands()[currentPlayer];
            if (playerHand.Any())
            {
                Card chosenCard = Display.ShowHands(currentPlayer, playerHand, moveOptions);
                bool posisi= true;
                gameController.PlayCard(currentPlayer, chosenCard,posisi);
            }
        }

        while (true){
            gameController.NextTurn(player =>
            {
                Dictionary<int, Card> moveOptions = gameController.GetPlayableMoves(player);
                var playerHand = gameController.GetHands()[player];
                if (playerHand.Any())
                {
                    Card chosenCard = Display.ShowHands(player, playerHand,moveOptions);
                    bool posisi = true;
                    gameController.PlayCard(player, chosenCard,posisi);
                    
                }
            });
        }     

    }
}

