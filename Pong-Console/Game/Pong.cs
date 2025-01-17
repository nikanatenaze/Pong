using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong_Console.Game
{
    internal class Pong
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Board Board { get; set; }
        public Paddle LeftPaddle { get; set; }
        public Paddle RightPaddle { get; set; }
        public Ball Ball { get; set; }
        ConsoleKey Key { get; set; }
        ConsoleKeyInfo ConsoleKeyInfo { get; set; }

        public Pong()
        {
            Height = 21;
            Width = 70;
            Board = new Board(Width, Height);
            LeftPaddle = new Paddle(2, Height);
            RightPaddle = new Paddle(Width - 2, Height);
            Ball = new Ball(Height, Width, (LeftPaddle, RightPaddle));
        }

        public void Input()
        {
            if(Console.KeyAvailable)
            {
                ConsoleKeyInfo = Console.ReadKey(true);
                Key = ConsoleKeyInfo.Key;
            }
        }

        public void Run()
        {
            Console.CursorVisible = false;
            while (true)
            {
                Board.Write();
                LeftPaddle.Write();
                RightPaddle.Write();
                Ball.Move();
                Input();
                if (Key == ConsoleKey.W)
                {
                    LeftPaddle.Up();
                    RightPaddle.Up();
                }
                if (Key == ConsoleKey.S)
                {
                    LeftPaddle.Down();
                    RightPaddle.Down();
                }
                Key = ConsoleKey.A;
                Thread.Sleep(50);
                Board.Write();
            }
        }
    }
}
