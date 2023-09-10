namespace Rock_Paper_Scissors_CSharp.lib;

public class GameModel
{
    //rock is o
    //paper is 1 
    //scissors is 2
    
    /// <summary>
    /// Represents the selection of the player
    /// </summary>
    public int? UserBet { get; set; }

    /// <summary>
    /// the program will store its random selection in here
    /// </summary>
    public int? ComputerBet { get; set; }

    /// <summary>
    /// User = 0
    /// Program = 1
    /// Draw = 2
    /// shows how won
    /// </summary>
    public int? Winner { get; set; }

    /// <summary>
    /// It looks like this: 0 : 1
    /// the current score of a game the player wanted to play again
    /// </summary>
    public int[] Score { get; set; }

    /// <summary>
    /// Counts how many times the user wanted to play again 
    /// </summary>
    public int Round { get; set; }
    
    public GameModel() {}
}