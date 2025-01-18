using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong_Console.Menu
{
    internal class GameMenu
    {
        public List<string> Values { get; set; }
        public (Func<object> func, int) Methods { get; set; }
        public List<((int, int), string)> ValuesPos { get; set; }
        public int Selected { get; set; }
        public int PrevSelected { get; set; }
        public int HeightLine { get; set; }
        public ConsoleKey Key { get; set; }
        public ConsoleKeyInfo KeyInfo { get; set; }
        public int ConsoleWidth { get; set; } = Console.WindowWidth;
        public int ConsoleHeight { get; set; } = Console.WindowHeight;

        public GameMenu(IEnumerable<string> values)
        {
            Selected = 0;
            HeightLine = 5;
            this.Values = values.ToList();
            this.ValuesPos = new List<((int, int), string)>();
        }


        public void Select()
        {
            Input();
            if (Key == ConsoleKey.Enter)
            {

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
        }

        public void Input()
        {
            if (Console.KeyAvailable)
            {
                KeyInfo = Console.ReadKey(true);
                Key = KeyInfo.Key;
            }
        }

        public void FillValuesPos()
        {

            (int, int) NextPosition = (ConsoleWidth / 2, HeightLine);
            foreach (var i in Values)
            {
                ValuesPos.Add(((NextPosition.Item1, NextPosition.Item2), i));
                NextPosition = (NextPosition.Item1, NextPosition.Item2 + 1);
            }
        }

        public void Write(((int, int), string) value, bool selected = false)
        {
            if (selected)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(value.Item1.Item1, value.Item1.Item2);
                Console.WriteLine($" * {value.Item2} * ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.SetCursorPosition(value.Item1.Item1, value.Item1.Item2);
                Console.WriteLine(value.Item2);
            }
        }

        public void WriteAll()
        {
            for (int i = 0; i < ValuesPos.Count; i++)
            {
                if(i == Selected)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(ValuesPos[i].Item1.Item1, ValuesPos[i].Item1.Item2);
                    Console.WriteLine($" * {ValuesPos[i].Item2} * ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.SetCursorPosition(ValuesPos[i].Item1.Item1, ValuesPos[i].Item1.Item2);
                    Console.WriteLine(ValuesPos[i].Item2);
                }
            }
        }

        public void Execute()
        {
            Console.CursorVisible = false;
            FillValuesPos();
            while (true)
            {
                while (true)
                {
                    Select();
                    WriteAll();
                    
                }
                Thread.Sleep(50);
            }
        }
    }
}
