namespace Pong_Console.Game
{
    internal class Ball
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int BoardHeight { get; set; }
        public int BoardWidth { get; set; }
        public (Paddle LeftPaddle, Paddle RightPaddle) Paddles { get; set; }
        public (int X, int Y) Direction { get; set; }

        public Ball(int BoardHeight, int BoardWidth, (Paddle, Paddle) paddles)
        {
            this.BoardHeight = BoardHeight;
            this.BoardWidth = BoardWidth;
            X = BoardWidth / 2;
            Y = BoardHeight / 2;
            SetRandomDirectionFromStart();
            Paddles = paddles;
        }

        private void SetRandomDirectionFromStart()
        {
            Random rnd = new Random();
            int random = rnd.Next(1, 3);
            if (random == 1)
            {
                var i = rnd.Next(2, 5);
                Direction = (i, 0);
            }
            else if (random == 2)
            {

                var i = rnd.Next(-4, -2);
                Direction = (i, 0);
            }
        }

        private void OnPaddle()
        {
            Random rnd = new Random();
            int NewXDirection;
            int NewYDirection;
            var LeftPaddleRage = (Paddles.LeftPaddle.Y - 1, Paddles.LeftPaddle.Y + Paddles.LeftPaddle.Length);
            var RightPaddleRage = (Paddles.RightPaddle.Y - 1, Paddles.RightPaddle.Y + Paddles.RightPaddle.Length);
            // paddles bounce
            if (Paddles.LeftPaddle.X + 1 == X)
            {
                if (Y! > LeftPaddleRage.Item1 && Y! < LeftPaddleRage.Item2)
                {
                    NewXDirection = rnd.Next(2, 5);
                    NewYDirection = rnd.Next(-2, 3);
                    Direction = (NewXDirection, NewYDirection);
                }
            }
            if (Paddles.RightPaddle.X - 1 == X)
            {
                if (Y! > RightPaddleRage.Item1 && Y! < RightPaddleRage.Item2)
                {
                    NewXDirection = rnd.Next(-4, 1);
                    NewYDirection = rnd.Next(-2, 3);
                    Direction = (NewXDirection, NewYDirection);
                }
            }
            // top and bottom bounce
            if (Y == 1)
            {
                var i = rnd.Next(0, 3);
                Direction = (Direction.X, i);
            }
            else if (Y == BoardHeight - 1)
            {
                var i = rnd.Next(-2, 0);
                Direction = (Direction.X, i);
            }
        }



        private void Safety()
        {
            var Left = (Paddles.LeftPaddle.Y - 1, Paddles.LeftPaddle.Y + Paddles.LeftPaddle.Length);
            var Right = (Paddles.RightPaddle.Y - 1, Paddles.RightPaddle.Y + Paddles.RightPaddle.Length);
            // border
            if (Math.Abs(Direction.X) > 1 || Math.Abs(Direction.Y) > 1) { 
                if(Direction.X < -1 && X + Direction.X <= 0)
                {
                    var i = BoardWidth - (BoardWidth - X);
                    Direction = (-i + 1, Direction.Y);
                }
                if(Direction.X > 1 && X + Direction.X >= BoardWidth)
                {
                    var i = BoardWidth -X;
                    Direction = (i - 1, Direction.Y);
                }
                if(Direction.Y < -1 && Y + Direction.Y <= 0)
                {
                    var i = BoardHeight - (BoardHeight - Y);
                    Direction = (Direction.X, -i + 1);
                } 
                if(Direction.Y > 1 && Y + Direction.Y >= BoardHeight)
                {
                    var i = BoardHeight - Y;
                    Direction = (Direction.X, i - 1);
                }
            }
            // paddle
            if (Math.Abs(Direction.X) > 1 || Math.Abs(Direction.Y) > 1)
            {
                if (X < BoardWidth / 2)
                {
                    if (Y >= Left.Item1 && Y <= Left.Item2 && Direction.X < -1)
                    {
                        if (X - Paddles.LeftPaddle.X <= Math.Abs(Direction.X))
                        {
                            var i = X - Paddles.LeftPaddle.X;
                            Direction = (-i + 1, Direction.Y);
                        }
                    }
                }
                if (X > BoardWidth / 2)
                {
                    if (Y >= Right.Item1 && Y <= Right.Item2 && Direction.X > 1)
                    {
                        if (Paddles.RightPaddle.X - X <= Direction.X)
                        {
                            var i = Paddles.RightPaddle.X - X;
                            Direction = (i - 1, Direction.Y);

                        }
                    }
                    
                }
            }
            X = X + Direction.X;
            Y = Y + Direction.Y;
        }

        private int Score()
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
                Safety();
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

        private void Write()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(X, Y);
            Console.WriteLine("■");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}