using Rock_Paper_Scissors_CSharp.lib;

//instance of the game
GameModel game = new GameModel();

//set the class for useful methods and structuring
Utils util = new Utils();

//check wanted gaming mode (user vs user OR user vs computer)
int gameMode = util.GetGameMode();

//set want game mode to play and adjust logic
//user vs user
if (gameMode == 1)
{
  //get users inputs
  int[] userChoices = util.UserVsUserGameOptions();

  game.UserOneBet = userChoices[0];
  game.UserTwoBet = userChoices[1];
  
}
//user vs computer
else if (gameMode == 2)
{
    
}

//check game and display result 
Checker.IsThereAWinner(game);
//TODO - look how to access files that are not in the bin file during runtime -> filenode
Render.RenderStart(game);

//ask for new game