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
        public int FirstScore { get; set; }
        public int SecondScore { get; set; }
        public Board(int width, int height, (int, int) Scores)
        {
            Width = width;
            Height = height;
            FirstScore = Scores.Item1;
            SecondScore = Scores.Item2;
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
                Console.WriteLine("▄");
            }
            for(int i = 0; i <= Width; i++)
            {
                Console.SetCursorPosition(i, Height);
                Console.WriteLine("▀");
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
            // borders
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("▄");
            Console.SetCursorPosition(Width, 0);
            Console.WriteLine("▄");
            Console.SetCursorPosition(0, Height);
            Console.WriteLine("▀");
            Console.SetCursorPosition(Width, Height);
            Console.WriteLine("▀");
            // Type score
            Console.SetCursorPosition(Width / 2 - 6, Height + 2);
            Console.WriteLine($"Player one: {FirstScore}");
            Console.SetCursorPosition(Width / 2 - 6, Height + 3);
            Console.WriteLine($"Player two: {SecondScore}");
        }
    }
}
