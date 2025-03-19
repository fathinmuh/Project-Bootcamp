namespace dominoesGame;

public class Board:IBoard{
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
    public Board()
    {
        playedCards = new List<Card>();
    }
}
