namespace dominoesGame;

public interface IBoard{
    void UpdateBoard(Card card, IPlayer player, bool posisi);
    List<Card> GetBoard();
}
