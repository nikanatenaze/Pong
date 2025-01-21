using Pong_Console.Game;
using Pong_Console.Menu;

Background background = new Background();
background.DisableFullSize();
background.DisableResize();
GameMenu game = new GameMenu(new List<string>() { "Start", "Exit" }, new List<Action>() { GameMenuMethods.Start, GameMenuMethods.Exit });
game.Execute();