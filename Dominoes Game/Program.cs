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

        int numPlayers = display.SetupPlayers();            
        var players = new List<IPlayer>();
        for (int i = 1; i <= numPlayers; i++)            
        {                
            string playerName = display.AssignPlayersName(i);                
            players.Add(new Player(i, playerName));            
        }
        gameController.AssignPlayers(players);


        gameController.StartGame(() =>        
        {                        
            gameController.DistributeCards(3);
            var firstPlayer = gameController.DetermineFirstPlayer();            
            display.ShowCurrentPlayer(firstPlayer);            
            gameController.RandomizeTurnOrder(firstPlayer);

            gameRunning = true;
            display.ShowBoard(gameController.GetBoardState());

        });

                 
        while (gameRunning)        
        {    
            if (firstPlayer != null)            
            {                
                var playerHand = gameController.GetHandValue()[firstPlayer];                
                if (playerHand.Any())                
                {                    
                    var moveOptions = gameController.GetPlayableMoves(firstPlayer);                    
                    Card chosenCard = display.ShowHand(firstPlayer, playerHand, moveOptions);                    
                    display.ShowBoard(gameController.GetBoardState());
                                    
                }            
            }        
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
                
                gameController.onGameOver = (isGameOver) =>
                {
                    if (isGameOver)
                    {
                        IPlayer winner = gameController.GetWinner();
                        display.ShowMessage($"Pemenangnya adalah: {winner.Name}\npermainan berakhir");
                        gameRunning=false;
                    }
                };

                // Panggil GameOver tanpa parameter
                if (gameController.CheckGameOver())
                {
                    gameController.GameOver();
                }
           
            });
        }
    }
}