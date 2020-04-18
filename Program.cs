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
            ConsoleInput consoleInput = new ConsoleInput(console);

            screens.LoadScreens(@"samples\simple_screen\", console);
            screens.RenderScreen("home");
            consoleInput.ReadInput();

            screens.UpdateFieldValue("home", "pages", 1);
            consoleInput.ReadInput();
            

            screens.UpdateFieldValue("home", "pages", 0);
            consoleInput.ReadInput();

            Environment.Exit(0);
        }
    }
}
