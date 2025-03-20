using System;
using dominoesGame;

public class Program{    
    public static void Main(string[] args)    
    {        
        Deck deck = new Deck();
        // Board board = new Board();        
        GameController gameController = new GameController(deck);
        IDisplay display = new Display();

        bool gameRunning=false;
        IPlayer firstPlayer = null;
        int distributedCard = 15;

        int numPlayers = display.SetupPlayers(distributedCard);            
        var players = new List<IPlayer>();
        for (int i = 1; i <= numPlayers; i++)            
        {                
            string playerName = display.AssignPlayersName(i);                
            players.Add(new Player(i, playerName));            
        }
        gameController.AssignPlayers(players);


        gameController.StartGame(() =>        
        {                        
            gameController.DistributeCards(distributedCard);
            var firstPlayer = gameController.DetermineFirstPlayer();            
            gameController.RandomizeTurnOrder(firstPlayer);

            display.ShowBoard(gameController.GetBoardState());
            display.ShowMessage($"{firstPlayer.Name} mulai duluan!");
            gameRunning = true; 
        });
                 
        while (gameRunning)        
        {    
            gameController.NextTurn(player =>            
            {                
                var moveOptions = gameController.GetPlayableMoves(player);                
                var playerHand = gameController.GetHandValue()[player];
                if (moveOptions.Any())                
                {                    
                    Card chosenCard = display.ShowHand(player, playerHand, moveOptions);
                    var (_, canPlaceLeft, canPlaceRight) = moveOptions[chosenCard.Id];
                    bool posisi = display.AssignPlacementSide(canPlaceLeft, canPlaceRight);
                    gameController.ExecuteMove(player, chosenCard, posisi);
                    display.ShowBoard(gameController.GetBoardState());                
                }
            });
            gameController.onGameOver = (isGameOver) =>
            {
                if (isGameOver)
                {
                    IPlayer winner = gameController.GetWinner();
                    display.ShowMessage($"Pemenangnya adalah: {winner.Name}\npermainan berakhir");
                    gameRunning=false;
                }
            };

            if (gameController.CheckGameOver())
            {
                gameController.GameOver();
            }
        }
    }
}