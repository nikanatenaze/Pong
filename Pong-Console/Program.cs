using Pong_Console.Game;
using Pong_Console.Menu;

GameMenu game = new GameMenu(new List<string>() { "Start", "Exit" }, new List<Action>() { GameMenuMethods.Start, GameMenuMethods.Exit });
game.Execute();