using Pong_Console.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong_Console.Menu
{
    public class MenuModels
    {
        public static GameMenu HomeMenu = new GameMenu(new List<string> { "Play game", "Options", "Exit"}, new List<Action> { MenuFunctions.StartModeMenu, MenuFunctions.StartOptionMenu }, true);
        public static GameMenu ChooseModeMenu = new GameMenu(new List<string> { "Versus bot", "Single", "One vs One", "Back" }, new List<Action> { MenuFunctions.VsBot, MenuFunctions.Single, MenuFunctions.OneVsOne }, true);
        //
        public static GameMenu OptionsMenu = new GameMenu(new List<string> { "Bot Difficulty", "Back" }, new List<Action> { MenuFunctions.StartBodDifficultyMenu }, true);
        public static GameMenu DifficultyOptions = new GameMenu(new List<string> { "Easy", "Normal", "Hard", "Back" }, new List<Action> { MenuFunctions.BotEasy, MenuFunctions.BotNormal, MenuFunctions.BotHand}, true);
    }

    public class MenuFunctions() {

        private static Pong Game = Game = new Pong();

        // Game mode menu functions
        public static void StartModeMenu()
        {
            MenuModels.ChooseModeMenu.Execute();
        }
        public static void VsBot() {
            
            Game.GameType = GameTypes.Bot;
            Game.Run();
        }
        public static void Single()
        {
            Game.GameType = GameTypes.Single;
            Game.Run();
        }
        public static void OneVsOne()
        {
            Game.GameType = GameTypes.OneVsOne;
            Game.Run();
        }

        // Change difficulty

        public static void StartBodDifficultyMenu()
        {
            MenuModels.DifficultyOptions.Execute();
        }

        public static void StartOptionMenu()
        {
            MenuModels.OptionsMenu.Execute();
        }

        public static void BotEasy()
        {
            Game.BotDifficulty = BotDifficulty.Easy;     
        }

        public static void BotNormal()
        {
            Game.BotDifficulty = BotDifficulty.Normal;
        }

        public static void BotHand()
        {
            Game.BotDifficulty = BotDifficulty.Hard;
        }
    }

}
