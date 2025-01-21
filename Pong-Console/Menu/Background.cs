using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Pong_Console.Menu
{
    internal class Background
    {
        // Import the necessary functions from kernel32.dll
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private const int GWL_STYLE = -16;
        private const int WS_THICKFRAME = 0x00040000;
        private const int WS_MAXIMIZEBOX = 0x00010000;

        public void DisableResize()
        {
            IntPtr consoleWindow = GetConsoleWindow();
            int currentStyle = GetWindowLong(consoleWindow, GWL_STYLE);
            SetWindowLong(consoleWindow, GWL_STYLE, currentStyle & ~WS_THICKFRAME);
        }

        public void EnableResize()
        {
            IntPtr consoleWindow = GetConsoleWindow();
            int currentStyle = GetWindowLong(consoleWindow, GWL_STYLE);
            SetWindowLong(consoleWindow, GWL_STYLE, currentStyle | WS_THICKFRAME);
        }

        public void DisableFullSize()
        {
            Console.BufferWidth = Console.WindowWidth;
            Console.BufferHeight = Console.WindowHeight;
            IntPtr consoleWindow = GetConsoleWindow();
            int style = GetWindowLong(consoleWindow, GWL_STYLE);
            SetWindowLong(consoleWindow, GWL_STYLE, style & ~WS_MAXIMIZEBOX);
        }
    }
}
