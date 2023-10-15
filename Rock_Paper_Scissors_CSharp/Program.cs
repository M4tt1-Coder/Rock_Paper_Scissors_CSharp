using Rock_Paper_Scissors_CSharp.lib;

//instance of the game
GameModel game = new GameModel();

//a goto statement to restart the game

//set the class for useful methods and structuring
Utils util = new Utils();

//show current score and round(when player played multiple games)
util.ShowScoreAndRound(game);

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
    // get game outputs 
    int[] userChoices = util.UserVsComputerOptions();

    game.UserOneBet = userChoices[0];
    game.UserTwoBet = userChoices[1];
}

//check game and display result 
Checker.IsThereAWinner(game);
Render.RenderStart(game);

//show final winner 
util.WriteWinnerInfo(game);

//TODO - rework the layout 
//-> creat rock, paper, scissors, vs layouts

//ask for new game