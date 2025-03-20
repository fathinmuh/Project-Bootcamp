namespace dominoesGame;

public class Display:IDisplay{    
    int boardCursorTop;   
    public void ShowBoard(List<Card> board)    
    {        
        for (int i = 0; i < Console.WindowHeight; i++)        
        {            
            Console.SetCursorPosition(0, boardCursorTop + i);            
            Console.Write(new string(' ', Console.WindowWidth));                    
        }        
        Console.Clear();        
        Console.WriteLine("=== Board Saat Ini ===");
        if (board.Count == 0)        
        {                
            Console.WriteLine("[ Board Kosong ]");            
            return;         
        }
        List<string[]> boardRows = new List<string[]>();
        foreach (var card in board)        
        {            
            string[] cardDisplay;            
            int first = card.FirstFaceValue;            
            int second = card.SecondFaceValue;
            if (first == second) // kartu dobel [3|3]            
            {                
                cardDisplay = new string[]                
                {                    
                    "┌───┐",                    
                    $"│ {first} │",                    
                    $"│ {second} │",                    
                    "└───┘"                
                };            
            }            
            else // kartu biasa [6|1]            
            {                
                cardDisplay = new string[]                
                {                    
                    "┌───┬───┐",                    
                    $"│ {first} │ {second} │",                    
                    "└───┴───┘"                
                };            
            }
            boardRows.Add(cardDisplay);        }
       
            int totalWidth = boardRows.Sum(c => c[0].Length + 1); // +1 untuk spasi antar kartu        
            int consoleWidth = Console.WindowWidth;

            // Jika terlalu panjang, sembunyikan kartu tengah        
            bool needShorten = totalWidth > consoleWidth;        
            int maxRows = boardRows.Max(c => c.Length);
            for (int row = 0; row < maxRows; row++)        
            {            
                for (int i = 0; i < boardRows.Count; i++)            
                {                
                    // Tampilkan hanya kartu pertama, terakhir, dan "..." di tengah                
                    if (needShorten && i > 0 && i < boardRows.Count - 1)                
                    {                    
                        if (i == 1) // Cetak "..." hanya sekali                    
                        {                        
                            Console.Write("  ...   ");                    
                        }                    
                        continue;                
                    }
                    string[] card = boardRows[i];                
                    if (row < card.Length)                    
                        Console.Write(card[row] + " ");                
                    else                    
                        Console.Write(new string(' ', card[0].Length) + " ");            
                }            
                Console.WriteLine();        
            }    
    }    
    public int SetupPlayers(int distributedCard)    
    {       
        Console.Write("Masukkan jumlah pemain (2-4): ");        
        int numPlayers;        
        int maxPlayer = 4;        
        while (!int.TryParse(Console.ReadLine(), out numPlayers) || numPlayers < 2 || numPlayers > maxPlayer || numPlayers*distributedCard > 28)        
        {            
            Console.Write("Input tidak valid! Masukkan jumlah pemain antara 2-4: ");        
        }
        return numPlayers;    
    }
    public string AssignPlayersName(int playerNumber)    
    {        
        Console.Write($"Masukkan nama untuk Pemain {playerNumber}: ");        
        return Console.ReadLine();    
    }
    public Card ShowHand(IPlayer player, List<Card> playerHand, Dictionary<int, (Card card, bool canPlaceLeft, bool canPlaceRight)> moveOptions)    
    {        
        Console.WriteLine();        
        Console.WriteLine($"{player.Name}, pilih kartu yang akan dimainkan:");                
        for (int i = 0; i < playerHand.Count; i++)        
        {            
            Card card = playerHand[i];            
            bool isPlayable = moveOptions.ContainsKey(card.Id);
            if (isPlayable)                
                Console.ForegroundColor = ConsoleColor.Green; // kartu bisa dimainkan            
            else                
                Console.ForegroundColor = ConsoleColor.White; // tidak bisa
            Console.Write($"{i + 1}. {card}  ");        
        }                
        Console.ResetColor();        
        Console.WriteLine();
        int choice;        
        while (true)        
        {            
            Console.Write("Pilih nomor kartu: ");            
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= playerHand.Count)            
            {                
                Card chosenCard = playerHand[choice - 1];
                if (moveOptions.ContainsKey(chosenCard.Id)) // Hanya izinkan kartu yang bisa dimainkan                    
                    return chosenCard;
                Console.WriteLine("Kartu ini tidak bisa dimainkan! Pilih kartu yang valid.");            
            }            
            else            
            {                
                Console.WriteLine("Pilihan tidak valid, coba lagi.");            
            }        
        }    
    }     
    public bool AssignPlacementSide(bool canPlaceLeft, bool canPlaceRight){        
        while (true)        
        {            
            Console.WriteLine("Pilih sisi untuk meletakkan kartu (kiri/kanan):");
            string? input = Console.ReadLine()?.ToLower();
            if (input == "kiri" && canPlaceLeft) return false;            
            if (input == "kanan" && canPlaceRight) return true;
            Console.WriteLine("Pilihan tidak valid! Pilih sisi yang sesuai dengan kartu.");        
        }    
    }
    public void ShowMessage(string message){
        Console.WriteLine(message);
    }

}
