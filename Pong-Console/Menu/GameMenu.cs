using System.Collections.Generic;

namespace Pong_Console.Menu
{
    internal class GameMenu
    {
        public List<string> Values { get; set; }
        public List<Action> Methods { get; set; }
        public List<((int, int), string)> ValuesPos { get; set; }
        public int Selected { get; set; }
        public int PrevSelected { get; set; }
        public int HeightLine { get; set; }
        public ConsoleKey Key { get; set; }
        public ConsoleKeyInfo KeyInfo { get; set; }
        public int ConsoleWidth { get; set; } = Console.WindowWidth;
        public int ConsoleHeight { get; set; } = Console.WindowHeight;

        public GameMenu(IEnumerable<string> values, IEnumerable<Action> actions)
        {
            Selected = 0;
            HeightLine = 5;
            this.Values = values.ToList();
            this.ValuesPos = new List<((int, int), string)>();
            this.Methods = actions.ToList();
        }


        public object Select()
        {
            Input();
            if (Key == ConsoleKey.Enter)
            {
                return Selected;
            }
            if (Key == ConsoleKey.W || Key == ConsoleKey.UpArrow)
            {
                if (Selected - 1 > -1)
                {
                    PrevSelected = Selected;
                    Selected--;
                }
            }
            if (Key == ConsoleKey.S || Key == ConsoleKey.DownArrow)
            {
                if (Selected + 1 < ValuesPos.Count)
                {
                    PrevSelected = Selected;
                    Selected++;
                }
            }
            Key = ConsoleKey.ExSel;
            return string.Empty;
        }

        public void Input()
        {
            if (Console.KeyAvailable)
            {
                KeyInfo = Console.ReadKey(true);
                Key = KeyInfo.Key;
            }
        }

        public void Write()
        {
            string threeSpaces = new string(' ', 3);
            for (int i = 0; i < ValuesPos.Count; i++)
            {
                var s = ValuesPos[i];
                if (i != Selected)
                {
                    Console.SetCursorPosition(s.Item1.Item1, s.Item1.Item2);
                    Console.WriteLine($"{threeSpaces}{s.Item2}{threeSpaces}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(s.Item1.Item1, s.Item1.Item2);
                    Console.WriteLine($" * {s.Item2} * ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
        }

        public void FillValuesPos()
        {
            int line = HeightLine;
            for (int i = 0; i < Values.Count; i++)
            {

                ValuesPos.Add(((ConsoleWidth / 2 - Values[i].Length / 2, line), Values[i]));
                line++;
            }
        }

        public void Execute()
        {
            Console.CursorVisible = false;
            FillValuesPos();
            while (true)
            {
                object result = Select();
                if (result == " ")
                {
                    Write();
                }
                if (result is int)
                {
                    Action meth = null;
                    foreach (var i in Methods)
                    {
                        object a = Methods.IndexOf(i);
                        if (a.Equals(result))
                        {
                            meth = i;
                            break;
                        }
                    }
                    if (meth != null)
                    {
                        Console.Clear();
                        meth.Invoke();
                    }

                }
                Write();
                Thread.Sleep(50);
            }
        }
    }
}
