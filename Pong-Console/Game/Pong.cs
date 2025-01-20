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
        public int Width { get; set; }
        public int Height { get; set; }
        public int PlayerOneScore { get; set; }
        public int PlayerTwoScore { get; set; }
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
            PlayerOneScore = 0;
            PlayerTwoScore = 0;
            LeftPaddle = new Paddle(2, Height);
            RightPaddle = new Paddle(Width - 2, Height);
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
                    Input();
                    if (Key == ConsoleKey.W)
                    {
                        LeftPaddle.Up();
                    }
                    if (Key == ConsoleKey.UpArrow)
                    {
                        RightPaddle.Up();
                    }
                    if (Key == ConsoleKey.DownArrow)
                    {
                        RightPaddle.Down();
                    }
                    if (Key == ConsoleKey.S)
                    {
                        LeftPaddle.Down();
                    }
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
