using Rock_Paper_Scissors_CSharp.utils;
using Rock_Paper_Scissors_CSharp.lib;

namespace Rock_Paper_Scissors_CSharp.lib;



/// <summary>
/// That's the node where the field in general is rendered.
/// It covers all special cases of playing and shows all depending pixel arts.s
/// </summary>
public static class Render
{ 
    //three methods for rock, paper and scissors each
    //one public method for start

    /// <summary>
    /// This is the entrypoint for the game to render.
    /// Calls the render methods for each symbol depending on the game conditions 
    /// </summary>
    /// <param name="game">the current instance of the game</param>
    public static void RenderStart(GameModel game)
    {
        //make sure that player and computer have made their choice
        if (game.UserOneBet == null && game.UserTwoBet == null)
        {
            return;
        }
        //check how to render the field -> what did the user select or computer?
        //-> after that call render methods for each symbol
        GameRenderer gameRenderer = new GameRenderer();
        gameRenderer.DisplayGame(game.UserOneBet, game.UserTwoBet);
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
    private const int Height = 10;
    
    /// <summary>
    /// Setting the width of the gaming field 
    /// </summary>
    private const int Width = 120;
    
    /// <summary>
    /// renders all special cases of the game
    /// </summary>
    /// <param name="userOneChoice">what the player selected</param>
    /// <param name="userTwoChoice">the random generated program choice</param>
    /// <returns></returns>
    public void DisplayGame(int? userOneChoice, int? userTwoChoice)
    {
        //Specific symbol layouts
        List<LayoutModel> layouts = FileNode.ConvertLayouts();

        List<int[]> rockLayout = layouts[0].Layout;
        
        List<int[]> paperLayout = layouts[1].Layout;
        
        List<int[]> scissorLayout = layouts[2].Layout;

        List<int[]> versusLayout = layouts[3].Layout;
        
        //will look from the sight of the player
        //rock cases
        if (userOneChoice == (int)GameOptions.Rock)
        {
            //user has rock : computer rock
            if (userTwoChoice == (int)GameOptions.Rock)
            {
                FieldRender(rockLayout, rockLayout, versusLayout);
            }

            //user rock : computer paper
            if (userTwoChoice == (int)GameOptions.Paper)
            {
                FieldRender(rockLayout, paperLayout, versusLayout);
            }

            //user rock : computer scissors
            if (userTwoChoice == (int)GameOptions.Scissor)
            {
                FieldRender(rockLayout, scissorLayout, versusLayout);
            }
        }

        //paper cases
        if (userOneChoice == (int)GameOptions.Paper)
        {
            //user paper : computer rock
            if (userTwoChoice == (int)GameOptions.Rock)
            {
                FieldRender(paperLayout, rockLayout, versusLayout);
            }

            //user paper : computer paper 
            if (userTwoChoice == (int)GameOptions.Paper)
            {
                FieldRender(paperLayout, paperLayout, versusLayout);
            }

            //user paper : computer scissors
            if (userTwoChoice == (int)GameOptions.Scissor)
            {
                FieldRender(paperLayout, scissorLayout, versusLayout);
            }
        }

        //scissor cases
        if (userOneChoice == (int)GameOptions.Scissor)
        {
            //user scissors : computer rock
            if (userTwoChoice == (int)GameOptions.Rock)
            {
                FieldRender(scissorLayout, rockLayout, versusLayout);
            }
            
            //user scissors : computer paper
            if (userTwoChoice == (int)GameOptions.Paper)
            {
                FieldRender(scissorLayout, paperLayout, versusLayout);
            }

            //user scissors : computer scissors
            if (userTwoChoice == (int)GameOptions.Scissor)
            {
                FieldRender(scissorLayout, scissorLayout, versusLayout);
            }
        }
    }

    private void FieldRender(List<int[]> firstSymbol, List<int[]> secondSymbol, List<int[]> versusCoordinates)
    {
        //constant versus setter coordinates 
        // var versusCoordinates = new List<int[]>
        // {
        //     new int[]{1,1},new int[]{8,1},new int[]{13,1},new int[]{14,1},new int[]{15,1},new int[]{16,1},new int[]{17,1},new int[]{18,1},
        //     new int[]{2,2},new int[]{7,2},new int[]{12,2},new int[]{2,3},new int[]{7,3},new int[]{11,3},new int[]{2,4},new int[]{7,4},new int[]{11,4},
        //     new int[]{12,4},new int[]{13,4},new int[]{14,4},new int[]{3,5},new int[]{6,5},new int[]{15,5},new int[]{16,5},new int[]{17,5},new int[]{18,5},
        //     new int[]{3,6},new int[]{6,6},new int[]{18,6},new int[]{3,7},new int[]{6,7},new int[]{17,7},new int[]{4,8},new int[]{5,8},new int[]{11,8},
        //     new int[]{12,8},new int[]{13,8},new int[]{14,8},new int[]{15,8},new int[]{16,8}
        // }; 
        //▄symbol
        //a 2 dimensional field
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                //in case that some symbol was found at the current coordinates
                bool noHit = true;
                
                //1.) render user symbol on the left
                foreach (var coordinate in firstSymbol)
                {
                    if (x == coordinate[0] && y == coordinate[1])
                    {
                        noHit = false;
                        Console.Write("\u2584");
                    }
                }
                //2.) vs in the middle
                foreach (var coordinate in versusCoordinates)
                {
                    if (x == coordinate[0] + 50 && y == coordinate[1])
                    {
                        noHit = false;
                        Console.Write("\u2584");
                    }
                }
                //3.) computer symbol on the right
                foreach (var coordinate in secondSymbol)
                {
                    if (x == coordinate[0] + 70 && y == coordinate[1])
                    {
                        noHit = false;
                        Console.Write("\u2584");
                    }
                }

                if (noHit)
                {
                    Console.Write(" ");
                }
            }
            
            Console.WriteLine();
        }
    }
}