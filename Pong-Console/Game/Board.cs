using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong_Console.Game
{
    internal class Board
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Board(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public Board() {
            Width = 75;
            Height = 21;
        }

        public void Write()
        {
            for(int i = 0; i <= Width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.WriteLine("▀");
            }
            for(int i = 0; i <= Width; i++)
            {
                Console.SetCursorPosition(i, Height);
                Console.WriteLine("▄");
            }
            for (int i = 0; i <= Height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine("█");
            }
            for (int i = 0; i <= Height; i++)
            {
                Console.SetCursorPosition(Width, i);
                Console.WriteLine("█");
            }
        }
    }
}
