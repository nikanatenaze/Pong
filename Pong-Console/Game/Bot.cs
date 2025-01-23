using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong_Console.Game
{
    internal class Bot
    {
        public Paddle BotPaddle { get; set; }
        public Bot(Paddle paddle)
        {
            BotPaddle = paddle;
        }

        
    }
}
