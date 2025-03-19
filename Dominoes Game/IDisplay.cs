namespace dominoesGame;

public interface IDisplay{

    void ShowBoard(List<Card> board);
    int SetupPlayers();
    string AssignPlayersName(int playerNumber);
    void ShowCurrentPlayer(IPlayer currentPlayer);
    Card ShowHand(IPlayer player, List<Card> playerHand, Dictionary<int, (Card card, bool canPlaceLeft, bool canPlaceRight)> moveOptions);
    bool AssignPlacementSide(bool canPlaceLeft, bool canPlaceRight);
    // void ShowWinner(IPlayer player);
    void ShowMessage(string message);
}
