using Pong_Console.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong_Console.Menu
{
    public class GameMenuMethods
    {
        public static void Start()
        {
            Console.Clear();
            Pong pong = new Pong();
            pong.Run();
        }

        public static void Exit()
        {
            Environment.Exit(0);
        }
    }
}
