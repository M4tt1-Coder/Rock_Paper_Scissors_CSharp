using Rock_Paper_Scissors_CSharp.utils;
using Rock_Paper_Scissors_CSharp.lib;

namespace Rock_Paper_Scissors_CSharp.lib;



/// <summary>
/// That's the node where the field in general is rendered.
/// It covers all special cases of playing and shows all depending pixel arts.s
/// </summary>
public class Render
{
    //three methods for rock, paper and scissors each
    //one public method for start

    /// <summary>
    /// This is the entrypoint for the game to render.
    /// Calls the render methods for each symbol depending on the game conditions 
    /// </summary>
    /// <param name="game">the current instance of the game</param>
    public void RenderStart(GameModel game)
    {
        //make sure that player and computer have made their choice
        if (game.UserBet == null && game.ComputerBet == null)
        {
            return;
        }
        //check how to render the field -> what did the user select or computer?

        //-> after that call render methods for each symbol
    }
}

/// <summary>
/// Represents a game renderer and what case should be rendered
/// </summary>
class GameRenderer
{
    //General field properties
    
    /// <summary>
    /// Setting the height of the gaming field
    /// </summary>
    private const int HEIGHT = 50;
    
    /// <summary>
    /// Setting the width of the gaming field 
    /// </summary>
    private const int WIDTH = 120;
    
    /// <summary>
    /// renders all special cases of the game
    /// </summary>
    /// <param name="userbet">what the player selected</param>
    /// <param name="computerbet">the random generated program choice</param>
    /// <returns></returns>
    public void DisplayGame(int userbet, int computerbet)
    {
        //Specific symbol layouts
        List<LayoutModel> layouts = FileNode.ConvertLayouts();

        List<int[]> RockLayout = layouts[0].Layout;

        List<int[]> PaperLayout = layouts[1].Layout;

        List<int[]> ScissorLayout = layouts[2].Layout;
        
        //will look from the sight of the player
        //rock cases
        if (GameOptions.Rock.Equals(userbet))
        {
            //user has rock : computer rock
            if (GameOptions.Rock.Equals(computerbet))
            {
                
            }

            //user rock : computer paper
            if (GameOptions.Paper.Equals(computerbet))
            {
            }

            //user rock : computer scissors
            if (GameOptions.Scissor.Equals(computerbet))
            {
            }
        }

        //paper cases
        if (GameOptions.Paper.Equals(userbet))
        {
            //user paper : computer rock
            if (GameOptions.Rock.Equals(computerbet))
            {
            }

            //user paper : computer paper 
            if (GameOptions.Paper.Equals(computerbet))
            {
            }

            //user paper : computer scissors
            if (GameOptions.Scissor.Equals(computerbet))
            {
            }
        }

        //scissor cases
        if (GameOptions.Scissor.Equals(userbet))
        {
            //user scissors : computer rock
            if (GameOptions.Rock.Equals(computerbet))
            {
            }
            
            //user scissors : computer paper
            if (GameOptions.Paper.Equals(computerbet))
            {
            }

            //user scissors : computer scissors
            if (GameOptions.Scissor.Equals(computerbet))
            {
            }
        }
    }

    public void FieldRender(List<int[]> firstSymbol, List<int[]> secondSymbol)
    {
        //constant versus setter coordinates 
        var versusCoordinates = new List<int[]> { }; 
        //▄symbol
        //a 2 dimensional field
        for (int y = 0; y < HEIGHT; y++)
        {
            for (int x = 0; x < WIDTH; x++)
            {
                //1.) render user symbol on the left
                foreach (var coordinate in firstSymbol)
                {
                    if (x == coordinate[0] && y == coordinate[1])
                    {
                        Console.Write("\u2584");
                    }
                }
                //2.) vs in the middle
                foreach (var coordinate in versusCoordinates)
                {
                    if (x == coordinate[0] && y == coordinate[1])
                    {
                        Console.Write("\u2584");
                    }
                }
                //3.) computer symbol on the right
                foreach (var coordinate in secondSymbol)
                {
                    if (x == coordinate[0] && y == coordinate[1])
                    {
                        Console.Write("\u2584");
                    }
                }
            }

            Console.WriteLine();
        }
    }
}