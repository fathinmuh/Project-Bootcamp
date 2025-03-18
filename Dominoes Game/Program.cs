﻿using System;
using dominoesGame;

public class Program{    
    public static void Main(string[] args)    
    {        
        Deck deck = new Deck();        
        GameController gameController = new GameController(deck);
        IDisplay display = new Display();

        gameController.StartGame(() =>        
        {            
            int numPlayers = display.SetupPlayers();            
            var players = new List<IPlayer>();
            for (int i = 1; i <= numPlayers; i++)            
            {                
                string playerName = display.AssignPlayersName(i);                
                players.Add(new Player(i, playerName));            
            }
            gameController.AssignPlayers(players);            
            gameController.DealCards(5);
            var currentPlayer = gameController.DetermineFirstPlayer();            
            display.ShowCurrentPlayer(currentPlayer);            
            gameController.RandomizeTurnOrder(currentPlayer);
            if (currentPlayer != null)            
            {                
                var playerHand = gameController.GetHandValue()[currentPlayer];                
                if (playerHand.Any())                
                {                    
                    var moveOptions = gameController.GetPlayableMoves(currentPlayer);                    
                    Card chosenCard = display.ShowHand(currentPlayer, playerHand, moveOptions);                    
                    bool posisi = true;                    
                    gameController.PlayCard(currentPlayer, chosenCard, posisi);
                    display.ShowBoard(gameController.GetBoardState());                
                }            
            }
        });
        bool gameRunning = true;         
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
                    gameController.PlayCard(player, chosenCard, posisi);
                    display.ShowBoard(gameController.GetBoardState());                
                }                
                else                
                {
                    display.ShowMessage("Tidak ada yang bisa mengeluarkan kartu");                          
                }            
                
                if (gameController.CheckGameOver()){
                    gameController.GameOver(isGameOver => 
                    {
                        if (isGameOver)
                        {
                            IPlayer winner = gameController.GetWinner();
                            display.ShowMessage($"Pemenang: {winner.Name}\nGameSelesai");
                            gameRunning=false;
                        }
                    });
                }
           
            });
        }
    }
}