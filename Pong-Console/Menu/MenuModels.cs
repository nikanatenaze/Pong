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
        public static GameMenu ChooseModeMenu = new GameMenu(new List<string> { "Vs bot", "Single", "1 vs 1", "Back" }, new List<Action> { }, true);
    }

    public class MenuFunctions() {
        public static void StartModeMenu()
        {
            MenuModels.ChooseModeMenu.Execute();
        }

    }

}
