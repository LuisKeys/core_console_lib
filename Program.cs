using System;
using System.Threading;

namespace core_console_lib
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleObj console = new ConsoleObj();
            ConsoleScreens screens = new ConsoleScreens();
            screens.LoadScreen(@"samples\simple_screen\home.yaml");

            ConsoleInput consoleInput = new ConsoleInput(console);
            ConsoleUIPrimitives consoleUI = new ConsoleUIPrimitives(console);

            consoleUI.DrawBox(32, 100, 2, 20);

            consoleInput.ReadInput();
            
            Environment.Exit(0);
        }
    }
}
