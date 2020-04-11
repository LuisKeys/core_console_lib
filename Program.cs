using System;

namespace core_console_lib
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleObj console = new ConsoleObj();
            ConsoleKeyInfo keyInfo;

            ConsoleUIPrimitives consoleUI = new ConsoleUIPrimitives(console);
            consoleUI.DrawHorizLine(10, 32, 100);
            console.Render();

            do            
            {
                keyInfo = console.ReadKey();
            }while(keyInfo.Key != ConsoleKey.Escape);

            console.Render();

            do            
            {
                keyInfo = console.ReadKey();
            }while(keyInfo.Key != ConsoleKey.Escape);
        }
    }
}
