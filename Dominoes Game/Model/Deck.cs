namespace dominoesGame;

public class Deck:IDeck{
    private IDisplay display;
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
        display = new Display();
        
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
        if (Cards.Count == 0) {
           display.ShowMessage("deck kosong");
        }   
  
        Card drawnCard = Cards[0];
        Cards.RemoveAt(0);
        return drawnCard;
        
    }
}
