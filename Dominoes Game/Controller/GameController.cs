namespace dominoesGame;

public class GameController{  
    private IDeck deck;    
    private IBoard board;
    private IDisplay display;   
    private List<IPlayer> players;    
    private Dictionary<IPlayer,List<Card>> hand;    
    private Dictionary<int, Card>? moveOptions;    
    private IPlayer? currentPlayer;    
    private int currentPlayerIndex=0;    
    public Action? onGameStart;    
    public Action<IPlayer>? onPlayerTurn;    
    public Action<bool>? onGameOver;

    public GameController(IDeck deck)    
    {        
        this.deck = deck;        
        this.deck.Shuffle();        
        players = new List<IPlayer>();        
        hand = new Dictionary<IPlayer, List<Card>>();        
        board=new Board(); 
        display=new Display();
    }    
    public void StartGame(Action onGameStart)    
    {        
        onGameStart?.Invoke();    
    }

    public void AssignPlayers(List<IPlayer> playerList)    
    {        
        players.AddRange(playerList);        
        foreach (var player in players)        
        {            
            hand[player] = new List<Card>();        
        }   
    }
    public void DistributeCards(int cardsPerPlayer)    
    {        
        foreach (var player in players)        
        {            
            for (int i = 0; i < cardsPerPlayer; i++)            
            {                
                if (deck==null) break;
                hand[player].Add(deck.DrawCard());             
            }        
        }    
    }
    public void ExecuteMove(IPlayer player, Card card, bool placeRight)    
    {        
        List<Card> boardCards = board.GetBoard();
        if (boardCards.Count > 0)        
        {            
            int leftValue = boardCards.First().FirstFaceValue;            
            int rightValue = boardCards.Last().SecondFaceValue;
            if (!placeRight && card.SecondFaceValue != leftValue)        
            {            
                (card.FirstFaceValue, card.SecondFaceValue) = (card.SecondFaceValue, card.FirstFaceValue);        
            }
            if (placeRight && card.FirstFaceValue != rightValue)        
            {            
                (card.FirstFaceValue, card.SecondFaceValue) = (card.SecondFaceValue, card.FirstFaceValue);        
            }
        }
        
        hand[player].Remove(card);        
        board.UpdateBoard(card, player, placeRight);            
    }

    public List<Card> GetBoardState()
    {
        return board.GetBoard();
    }
    public Dictionary<IPlayer, List<Card>> GetHandValue()    
    {        
        return hand;    
    }
    public IPlayer? DetermineFirstPlayer()    
    {        
        var highestDouble = players            
            .SelectMany(p => hand[p], (player, card) => new { player, card })            
            .Where(x => x.card.IsDouble())            
            .OrderByDescending(x => x.card.GetHighestValue())            
            .FirstOrDefault();
        if (highestDouble != null)
            return highestDouble.player; 

        var highestValueCard = players
            .SelectMany(p => hand[p], (player, card) => new { player, card })
            .OrderByDescending(x => Math.Max(x.card.FirstFaceValue, x.card.SecondFaceValue))
            .FirstOrDefault();

        return highestValueCard?.player;  
    }
    public void RandomizeTurnOrder(IPlayer currentPlayer)    
    {       
        Random rng = new Random();              
        players = players
        .Where(p => p != currentPlayer)
        .OrderBy(p => rng.Next()).ToList();
        // .OrderBy(_ => Guid.NewGuid()).ToList();            
        players.Insert(1,currentPlayer);        
    }    
    public void NextTurn(Action<IPlayer?> onPlayerTurn)    
    {        
        if (players.Count == 0) return;

        PassTurn();
        onPlayerTurn(currentPlayer);
    }
    public void PassTurn()    
    {        
        int startIndex = currentPlayerIndex;
        do        
        {            
            currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;            
            currentPlayer = players[currentPlayerIndex];
            var moveOptions = GetPlayableMoves(currentPlayer);            

            if (moveOptions.Any()) return;

            display.ShowMessage($"{currentPlayer.Name} tidak bisa bermain, giliran dilewati.");        

        } while (currentPlayerIndex != startIndex);
        // return null;
    }
    public Dictionary<int, (Card,bool canPlaceLeft, bool canPlaceRight)> GetPlayableMoves(IPlayer player)    
    {        
        List<Card> boardCards = board.GetBoard();        
        var moveOptions = new Dictionary<int, (Card,bool,bool)>();        
        if (boardCards.Count == 0)        
        {           
            foreach (var card in hand[player])            
            {                
                moveOptions[card.Id] = (card, true, true);            
            }            
            return moveOptions;        
        }                
        int leftValue = boardCards.First().FirstFaceValue;    //ambil nilai pojok kiri    
        int rightValue = boardCards.Last().SecondFaceValue;   //ambil nilai pojok kanan
        foreach (Card card in hand[player])        
        {            
            bool canPlaceLeft = (card.FirstFaceValue == leftValue || card.SecondFaceValue == leftValue);            
            bool canPlaceRight = (card.FirstFaceValue == rightValue || card.SecondFaceValue == rightValue);
            if (canPlaceLeft || canPlaceRight)            
            {               
                moveOptions[card.Id] = (card, canPlaceLeft, canPlaceRight);            
            }        
        }        
        return moveOptions;            
    }

    public bool CheckGameOver()
    {
        return players.Any(p => hand[p].Count == 0) || players.All(p => GetPlayableMoves(p).Count == 0);
    }

    public int GetValue(Card card)
    {
        return card.FirstFaceValue + card.SecondFaceValue;
    }

    public int GetScore(IPlayer player)
    {
        return hand[player].Sum(card => GetValue(card));
    }

    public IPlayer GetWinner()
    {
        foreach (var player in players)
        {
            if (hand[player].Count == 0)
            {
                return player;
            }
        }

        var playerScores = players
            .Select(p => new
            {
                Player = p,
                TotalPoints = GetScore(p)
            })
            .OrderBy(p => p.TotalPoints) // Urutkan berdasarkan total nilai terkecil
            .ToList();

        return playerScores.First().Player;
    }

    public void GameOver()
    {
        bool isGameOver = CheckGameOver();

        onGameOver?.Invoke(isGameOver);
    }

}
