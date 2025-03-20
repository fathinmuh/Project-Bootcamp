namespace dominoesGame;

public interface IDisplay{

    void ShowBoard(List<Card> board);
    int SetupPlayers(int sumCard);
    string AssignPlayersName(int playerNumber);
    Card ShowHand(IPlayer player, List<Card> playerHand, Dictionary<int, (Card card, bool canPlaceLeft, bool canPlaceRight)> moveOptions);
    bool AssignPlacementSide(bool canPlaceLeft, bool canPlaceRight);
    void ShowMessage(string message);
}
