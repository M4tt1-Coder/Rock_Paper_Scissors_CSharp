namespace Rock_Paper_Scissors_CSharp.lib;

/// <summary>
/// Looks if all game rules are valid and if there is a winner
/// </summary>
public static class Checker
{
    //set a winner when there is one
    //update score after every round
    
    /// <summary>
    /// The main entrance function to the checker
    /// updates all properties of the game
    /// called after every single round
    /// </summary>
    /// <param name="game">current game instance</param>
    public static void IsThereAWinner(GameModel game)
    {
        //go through all cases to win
        SetWinner(game);
        //call update functions
        UpdateScore(game);
        UpdateRound(game);
    }

    /// <summary>
    /// When the game round result isn't a draw then it will
    /// increase the score of the winner with 1
    /// </summary>
    /// <param name="game">game instance of the current round</param>
    private static void UpdateScore(GameModel game)
    {
        if (game.Winner != 2)
        {
            if (game.Winner == 0)
            {
                game.Score[0] += 1;
            }
            else if (game.Winner == 1)
            {
                game.Score[1] += 1;
            }
            
        }
    }
    
    /// <summary>
    /// Updates the round of the game
    /// </summary>
    /// <param name="game">current instance of the game</param>
    private static void UpdateRound(GameModel game)
    {
        game.Round += 1;
    }

    /// <summary>
    /// Checks all winning cases out of the view from the player
    /// but all possibilities are covered 
    /// </summary>
    /// <param name="game">game instance</param>
    private static void SetWinner(GameModel game)
    {
        //check with user bet = rock
        if (game.UserOneBet == 0 && game.UserTwoBet == 0)
        {
            game.Winner = 2;
        }

        if (game.UserOneBet == 0 && game.UserTwoBet == 1)
        {
            game.Winner = 1;
        }

        if (game.UserOneBet == 0 && game.UserTwoBet == 2)
        {
            game.Winner = 0;
        }
        
        //check with paper 
        if (game.UserOneBet == 1 && game.UserTwoBet == 0)
        {
            game.Winner = 0;
        }

        if (game.UserOneBet == 1 && game.UserTwoBet == 1)
        {
            game.Winner = 2;
        }

        if (game.UserOneBet == 1 && game.UserTwoBet == 2)
        {
            game.Winner = 1;
        }
        
        //check with scissors
        if (game.UserOneBet == 2 && game.UserTwoBet == 0)
        {
            game.Winner = 1;
        }

        if (game.UserOneBet == 2 && game.UserTwoBet == 1)
        {
            game.Winner = 0;
        }

        if (game.UserOneBet == 2 && game.UserTwoBet == 2)
        {
            game.Winner = 2;
        }
    }
}