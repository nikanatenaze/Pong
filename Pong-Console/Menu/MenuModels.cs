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
        public static GameMenu HomeMenu = new GameMenu(new List<string> { "Play game", "Exit"}, new List<Action> { MenuFunctions.StartModeMenu }, true);
        public static GameMenu ChooseModeMenu = new GameMenu(new List<string> { "Versus bot", "Single", "One vs One", "Back" }, new List<Action> { MenuFunctions.VsBot, MenuFunctions.Single, MenuFunctions.OneVsOne }, true);
    }

    public class MenuFunctions() {

        private static Pong Game = Game = new Pong();
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
    }

}
