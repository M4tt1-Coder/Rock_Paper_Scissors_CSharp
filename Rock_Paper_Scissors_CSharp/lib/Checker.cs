namespace Rock_Paper_Scissors_CSharp.lib;

/// <summary>
/// Looks if all game rules are valid and if there is a winner
/// </summary>
public class Checker
{
    //set a winner when there is one
    //update score after every round
    
    /// <summary>
    /// The main entrance function to the checker
    /// updates all properties of the game
    /// called after every single round
    /// </summary>
    /// <param name="game">current game instance</param>
    public void IsThereAWinner(GameModel game)
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
    private void UpdateScore(GameModel game)
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
    private void UpdateRound(GameModel game)
    {
        game.Round += 1;
    }

    /// <summary>
    /// Checks all winning cases out of the view from the player
    /// but all possibilities are covered 
    /// </summary>
    /// <param name="game">game instance</param>
    private void SetWinner(GameModel game)
    {
        //check with user bet = rock
        if (game.UserBet == 0 && game.ComputerBet == 0)
        {
            game.Winner = 2;
        }

        if (game.UserBet == 0 && game.ComputerBet == 1)
        {
            game.Winner = 1;
        }

        if (game.UserBet == 0 && game.ComputerBet == 2)
        {
            game.Winner = 0;
        }
        
        //check with paper 
        if (game.UserBet == 1 && game.ComputerBet == 0)
        {
            game.Winner = 0;
        }

        if (game.UserBet == 1 && game.ComputerBet == 1)
        {
            game.Winner = 2;
        }

        if (game.UserBet == 1 && game.ComputerBet == 2)
        {
            game.Winner = 1;
        }
        
        //check with scissors
        if (game.UserBet == 2 && game.ComputerBet == 0)
        {
            game.Winner = 1;
        }

        if (game.UserBet == 2 && game.ComputerBet == 1)
        {
            game.Winner = 0;
        }

        if (game.UserBet == 2 && game.ComputerBet == 2)
        {
            game.Winner = 2;
        }
    }
}