using System;

namespace core_console_lib
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleObj console = new ConsoleObj();
            ConsoleInput consoleInput = new ConsoleInput(console);

            ConsoleUIPrimitives consoleUI = new ConsoleUIPrimitives(console);
            consoleUI.DrawHorizLine(0, 32, 100);
            console.SetColors(ConsoleColor.DarkGreen, ConsoleColor.DarkRed);
            consoleUI.DrawHorizLine(1, 32, 100);
            console.SetColors(ConsoleColor.DarkGreen, ConsoleColor.Black);

            consoleInput.ReadInput();

            consoleUI.DrawHorizLine(2, 32, 100);
            consoleUI.DrawHorizLine(3, 32, 100);
            console.SetColors(ConsoleColor.DarkGreen, ConsoleColor.Black);

            consoleInput.ReadInput();
            
            Environment.Exit(0);
        }
    }
}
