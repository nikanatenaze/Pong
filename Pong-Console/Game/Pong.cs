using Pong_Console.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong_Console.Game
{
    internal class Pong
    {
        private int Width { get; set; }
        private int Height { get; set; }
        private int PlayerOneScore { get; set; }
        private int PlayerTwoScore { get; set; }
        private Bot Bot { get; set; }
        private Board Board { get; set; }
        private Paddle LeftPaddle { get; set; }
        private Paddle RightPaddle { get; set; }
        private Ball Ball { get; set; }
        private ConsoleKey Key { get; set; }
        public GameTypes GameType { get; set; }
        private ConsoleKeyInfo ConsoleKeyInfo { get; set; }

        public Pong()
        {
            GameType = GameTypes.Bot;
            Height = 21;
            Width = 70;
            PlayerOneScore = 0;
            PlayerTwoScore = 0;
            LeftPaddle = new Paddle(2, Height);
            RightPaddle = new Paddle(Width - 2, Height);
            Bot = new Bot(LeftPaddle);
            Ball = new Ball(Height, Width, (LeftPaddle, RightPaddle));
            Board = new Board(Width, Height, (PlayerOneScore, PlayerTwoScore));
        }

        private void Input()
        {
            if(Console.KeyAvailable)
            {
                ConsoleKeyInfo = Console.ReadKey(true);
                Key = ConsoleKeyInfo.Key;
            }
        }

        private bool CheckGame()
        {
            if(PlayerOneScore == 3 || PlayerTwoScore == 3)
                return true;
            return false;
        }

        private void CreateNewRound(bool createAll = false)
        {
            Ball = new Ball(Height, Width, (LeftPaddle, RightPaddle));
            Board = new Board(Width, Height, (PlayerOneScore, PlayerTwoScore));
            if(createAll)
            {
                LeftPaddle = new Paddle(2, Height);
                RightPaddle = new Paddle(Width - 2, Height);
                PlayerOneScore = 0;
                PlayerTwoScore = 0;
            }
        }

        public void RunBot()
        {
            if(Ball.X < Width / 2)
            {
                if (Ball.Y > LeftPaddle.Y + LeftPaddle.Length / 2)
                {
                    LeftPaddle.Down();
                }
                if (Ball.Y < LeftPaddle.Y + LeftPaddle.Length / 2)
                {
                    LeftPaddle.Up();
                }
            }
        }

        // Maybe not optimised... but comeon its console
        public void GameController()
        {
            Input();
            if (GameType == GameTypes.Bot)
            {
                RunBot();
                if (Key == ConsoleKey.DownArrow || Key == ConsoleKey.S)
                {
                    RightPaddle.Down();
                }
                if (Key == ConsoleKey.UpArrow || Key == ConsoleKey.W)
                {
                    RightPaddle.Up();
                }
            }
            else if(GameType == GameTypes.Single) {
                if (Key == ConsoleKey.DownArrow || Key == ConsoleKey.S)
                {
                    LeftPaddle.Down();
                    RightPaddle.Down();
                }
                if (Key == ConsoleKey.UpArrow || Key == ConsoleKey.W)
                {
                    LeftPaddle.Up();
                    RightPaddle.Up();
                }
            }
            else if (GameType == GameTypes.OneVsOne)
            {
                if (Key == ConsoleKey.W)
                {
                    LeftPaddle.Down();
                }
                if (Key == ConsoleKey.S)
                {
                    LeftPaddle.Up();
                }
                if (Key == ConsoleKey.DownArrow)
                {
                    RightPaddle.Down();
                }
                if (Key == ConsoleKey.UpArrow)
                {
                    RightPaddle.Up();
                }
            }
        }

        public void Run()
        {
            Console.CursorVisible = false;
            CreateNewRound(true);
            while (!CheckGame())
            {
                Board.Write();
                LeftPaddle.Write();
                RightPaddle.Write();
                int BallResult = Ball.Move();
                if (BallResult == 0)
                {
                    GameController();
                }
                else if (BallResult == 1)
                {
                    PlayerOneScore++;
                    CreateNewRound();
                }
                else if (BallResult == 2)
                {
                    PlayerTwoScore++;
                    CreateNewRound();
                }
                Key = ConsoleKey.A;
                Thread.Sleep(50);
                Board.Write();
                
            }
        }
    }
}
