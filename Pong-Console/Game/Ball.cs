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
                var i = rnd.Next(-3, 0);
                Direction = (i, 0);
            }
            else if (random == 2)
            {
                var i = rnd.Next(1, 4);
                Direction = (i, 0);
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
                    NewXDirection = rnd.Next(1, 4);
                    NewYDirection = rnd.Next(-2, 3);
                    Direction = (NewXDirection, NewYDirection);
                }
            }
            if (RightPaddle.X - 1 == X)
            {
                if (Y! > RightPaddleRage.Item1 && Y! < RightPaddleRage.Item2)
                {
                    NewXDirection = rnd.Next(-4, -1);
                    NewYDirection = rnd.Next(-2, 3);
                    Direction = (NewXDirection, NewYDirection);
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

        public void PaddleSafe()
        {
            var LeftPaddle = Paddles.Item1;
            var RightPaddle = Paddles.Item2;
            if (Direction.Item1 > -1 && Direction.Item1 - X >= LeftPaddle.X)
            {
                Console.WriteLine(321);
                X = X - 1;
            }
            else if (Direction.Item1 > 1 && Direction.Item1 + X >= RightPaddle.X)
            {
                Console.WriteLine(123);
                X = X + 1;
            }
            else
            {
                X = X + Direction.Item1;
            }
        }

        public void Move()
        {
            Console.WriteLine(Direction);
            Console.CursorVisible = false;
            Console.SetCursorPosition(X, Y);
            Console.WriteLine(" ");
            PaddleSafe();
            if(Direction.Item2 < -1 && Direction.Item2 - Y <= 0)
            {
                Y = Y + 1;
            }
            else if (Direction.Item2 > 1 && Direction.Item2 - Y <= BoardHeight)
            {
                Y = Y - 1;
            }
            else
            {
                Y = Y + Direction.Item2;
            }
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
