using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong_Console.Game
{
    internal class Paddle
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Length { get; set; }
        public int BoardHeight { get; set; }

        public Paddle(int x, int BoardHeight)
        {
            X = x;
            Length = BoardHeight / 3;
            Y = BoardHeight / 2 - Length / 2;
            this.BoardHeight = BoardHeight;
        }

        public bool Check(bool up = false)
        {
            if (up && Y - 1 == 0) { return false; }
            if (!up)
            {
                if (Y + Length == BoardHeight) { return false; }
            }
            return true;
        }

        public void Up()
        {
            if(Check(true))
            {
                for (int i = 0; i < Length; i++)
                {
                    Console.SetCursorPosition(X, i + Y);
                    Console.WriteLine(" ");
                }
                Y--;
                Write();
            }
        }
        public void Down()
        {
            if (Check())
            {
                for (int i = 0; i < Length; i++)
                {
                    Console.SetCursorPosition(X, i + Y);
                    Console.WriteLine(" ");
                }
                Y++;
                Write();
            }
        }

        public void Write()
        {
            for (int i = 0; i < Length; i++) { 
                Console.SetCursorPosition(X, i + Y);
                Console.WriteLine("|");
            }
        }
    }
}
