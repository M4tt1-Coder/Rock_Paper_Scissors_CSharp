using System.Net.Mime;

namespace Rock_Paper_Scissors_CSharp.lib;

/// <summary>
/// Useful methods for the game
/// </summary>
public class Utils
{
    /// <summary>
    /// If the player wants to play:
    /// -> User VS User then it gets both players choices
    /// stores them in a integer array -> (index) [0] = user 1 choice || [1] = user 2 choice  
    /// </summary>
    /// <returns>integer array with user game option choices</returns>
    public int[] UserVsUserGameOptions()
    {
        int tries = 3;
        
        
        tryUserVsUserOptionsAgain:
        try
        {
            if (tries == 0)
            {
                Console.WriteLine("You have failed too ofter please restart!");
                Thread.Sleep(1000);
                Environment.Exit(0);
            }
            
            Console.WriteLine("There are 3 options to choose: Rock = [1]; Paper = [2]; Scissors = [3]");
            //get user 1 input
            Console.WriteLine("Player 1 your choice please!");
            Console.Write("=> : ");
            int decisionUser1 = Convert.ToInt16(Console.ReadLine());
        
            //so that player 2 doesn't see player 1 his choice
            Console.Clear();
        
            Console.WriteLine("There are 3 options to choose: Rock = [1]; Paper = [2]; Scissors = [3]");
            //get user 2 input 
            Console.WriteLine("Player 2 your choice please!");
            Console.Write("=> : ");
            int decisionUser2 = Convert.ToInt16(Console.ReadLine());

            //check if inputs where valid
            if (decisionUser1 > 3 || decisionUser1 < 1 || decisionUser2 > 3 || decisionUser2 < 1)
            {
                Console.WriteLine("Please enter a choice index that is valid!");
                Console.Clear();
                goto tryUserVsUserOptionsAgain;
            }
            
            //to match with the index of the game options
            decisionUser1 -= 1;
            decisionUser2 -= 1;
            
            int[] output = new int[]{ decisionUser1, decisionUser2};

            return output;
        }
        catch
        {
            Console.WriteLine("Please give valid answers!");
            Console.Clear();
            tries -= 1;
            goto tryUserVsUserOptionsAgain;
        }
    }
    
    /// <summary>
    /// Simplify the readability of program.cs:
    /// asks for the user's game mode choice
    /// -> checks the input; when it's invalid repeat the input demand
    /// </summary>
    /// <returns>user decision what game mode to play represented as an integer</returns>
    public int GetGameMode()
    {
        //statement for a new try to get the game mode 
        newTryGettingGameMode:
        
        //present all game modes
        Console.WriteLine("There are 2 playing modes: ");
        Console.WriteLine("1) [User] VS [User] -> player plays against another player");
        Console.WriteLine("2) [User] VS [Computer] -> the user competes with the computer");

        //ask for game choice 

        Console.WriteLine("Enter [1] for game mode number 1 and [2] number 2!");
        Console.Write("Your Answer: ");
        var answer = Console.ReadLine();
        var userChoice = Convert.ToInt16(answer?.Trim());

        if (userChoice != 1 && userChoice != 2)
        {
            Console.WriteLine("__________");
            Console.WriteLine("You entered answer wasn't in the right format! Please try again!");
            Console.WriteLine("__________");
            goto newTryGettingGameMode;
        }

        return userChoice;
    }
    
    /// <summary>
    /// Will be accessed at program.cs to get a game option of the computer
    ///
    /// Generates a integer between 0 - 2 : -> which are the indexes of the all game options 
    /// </summary>
    /// <returns>random index of a game option</returns>
    public int RandomChoice()
    {
        Random generator = new Random();

        int output = generator.Next(0, 3);

        return output;
    }
    
    /// <summary>
    /// When the player wants to play a new game
    /// -> it prepares a the game instance for a new round
    ///     -> resets all game options choices and winner property 
    /// </summary>
    /// <param name="game">represents the game object</param>
    public void PrepareNewGame(GameModel game)
    {
        game.UserOneBet = null;
        game.UserTwoBet = null;
        game.Winner = null;
    }
}