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
            console.SetColors(ConsoleColor.DarkGreen, ConsoleColor.DarkRed);
            consoleUI.DrawHorizLine(0, 32, 100);
            consoleUI.DrawHorizLine(1, 32, 100);

            consoleInput.ReadInput();

            consoleUI.DrawHorizLine(2, 32, 100);
            consoleUI.DrawHorizLine(3, 32, 100);

            consoleInput.ReadInput();
            
            Environment.Exit(0);
        }
    }
}
