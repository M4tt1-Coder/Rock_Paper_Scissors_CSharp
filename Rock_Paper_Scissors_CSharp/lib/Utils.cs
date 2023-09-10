namespace Rock_Paper_Scissors_CSharp.lib;

/// <summary>
/// Useful methods for the game
/// </summary>
public class Utils
{
    public void PrepareNewGame(GameModel game)
    {
        game.UserBet = null;
        game.ComputerBet = null;
        game.Winner = null;
    }
}