namespace Pong_Console.Game
{
    internal class Ball
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int BoardHeight { get; set; }
        public int BoardWidth { get; set; }
        public (Paddle, Paddle) Paddles { get; set; }
        public (int, int) Direction { get; set; }

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
            if (random == 1)
            {
                var i = rnd.Next(-3, 0);
                Direction = (3, 0);
            }
            else if (random == 2)
            {
                var i = rnd.Next(1, 4);
                Direction = (3, 0);
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
                if (Y! > LeftPaddleRage.Item1 && Y! < LeftPaddleRage.Item2)
                {
                    NewXDirection = rnd.Next(1, 4);
                    NewYDirection = rnd.Next(-2, 3);
                    while (NewXDirection == -3)
                    {
                        NewXDirection = rnd.Next(-4, -1);
                    }
                    Direction = (NewXDirection, NewYDirection);
                }
            }
            if (RightPaddle.X - 1 == X)
            {
                if (Y! > RightPaddleRage.Item1 && Y! < RightPaddleRage.Item2)
                {
                    NewXDirection = rnd.Next(-4, -1);
                    NewYDirection = rnd.Next(-2, 3);
                    while (NewXDirection == -3)
                    {
                        NewXDirection = rnd.Next(-4, -1);
                    }
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

        public void SafePaddle()
        {
            var LeftPaddle = Paddles.Item1;
            var RightPaddle = Paddles.Item2;
            if (Direction.Item1 > 1 && X + Direction.Item1 >= RightPaddle.X)
            {
                X++;
            }
            else if (Direction.Item1 < -1 && X - Direction.Item1 <= LeftPaddle.X)
            {
                X--;
            }
            else
            {
                X = X + Direction.Item1;
            }
        }
        public void SafeBoarder()
        {
            if (Direction.Item2 < -1 && Direction.Item2 - Y <= 0)
            {
                Y++;
            }
            else if (Direction.Item2 > 1 && Direction.Item2 - Y <= BoardHeight)
            {
                Y--;
            }
            else
            {
                Y = Y + Direction.Item2;
            }
        }


        public int Score()
        {
            if(X == 1)
            {
                return 1;
            }
            if(X == BoardWidth - 1)
            {
                return 2;
            }
            return 0;
        }
        public int Move()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(X, Y);
            Console.WriteLine(" ");
            int result = Score();
            if (result == 0)
            {
                SafePaddle();
                SafeBoarder();
                OnPaddle();
                Write();
            }  
            if(result == 1 || result == 2)
            {
                return result;
            }
            Thread.Sleep(50);
            return 0;
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