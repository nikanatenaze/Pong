using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong_Console.Game
{
    internal class Ball
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int BoardHeight { get; set; }
        public int BoardWidth { get; set; }
        public (Paddle, Paddle) Paddles { get; set; }
        public (int,int) Direction { get; set; }

        public Ball(int BoardHeight, int BoardWidth, (Paddle, Paddle) paddles)
        {
            this.BoardHeight = BoardHeight;
            this.BoardWidth = BoardWidth;
            X = BoardWidth / 2;
            Y = BoardHeight / 2;
            SetRandomDirectionFromStart();
            Paddles = paddles;
        }

        public void SetRandomDirectionFromStart()
        {
            Random rnd = new Random();
            int random = rnd.Next(1, 3);
            if(random == 1)
            {
                Direction = (-1, 0);
            }
            else if (random == 2)
            {
                Direction = (1, 0);
            }
        }

        public void OnPaddle()
        {
            Random rnd = new Random();
            int NewXDirection;
            int NewYDirection;
            var LeftPaddle = Paddles.Item1;
            var RightPaddle = Paddles.Item2;
            var LeftPaddleRage = (LeftPaddle.Y - 1, LeftPaddle.Y + LeftPaddle.Length);
            var RightPaddleRage = (RightPaddle.Y - 1, RightPaddle.Y + RightPaddle.Length);
            if (LeftPaddle.X + 1 == X)
            {
                if(Y !> LeftPaddleRage.Item1 && Y !< LeftPaddleRage.Item2)
                {
                    NewXDirection = rnd.Next(1, 3);
                    NewYDirection = rnd.Next(-1, 2);
                    Direction = (1, NewYDirection);
                }
            }
            if (RightPaddle.X - 1 == X)
            {
                if (Y! > RightPaddleRage.Item1 && Y! < RightPaddleRage.Item2)
                {
                    NewXDirection = rnd.Next(-3, -1);
                    NewYDirection = rnd.Next(-1, 2);
                    Direction = (-1, NewYDirection);
                }
            }
            if (Y == 1)
            {
                Direction = (Direction.Item1, rnd.Next(1, 2));
            }
            else if (Y == BoardHeight - 1)
            {
                Direction = (Direction.Item1, rnd.Next(-1, 0));
            }
        }

        public void Move()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(X, Y);
            Console.WriteLine(" ");
            X = X + Direction.Item1;
            Y = Y + Direction.Item2;
            OnPaddle();
            Write();
            Thread.Sleep(50);
        }

        public void Write()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(X, Y);
            Console.WriteLine("■");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
