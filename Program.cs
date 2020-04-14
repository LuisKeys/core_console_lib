using System;
using System.Threading;

namespace core_console_lib
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleObj console = new ConsoleObj();
            YAMLReader yamlReader = new YAMLReader();
            yamlReader.Read(@"samples\simple_screen\home.yaml");
            console.SetColors(ConsoleColor.DarkCyan, ConsoleColor.Black, ConsoleColor.Black);
            ConsoleInput consoleInput = new ConsoleInput(console);
            ConsoleUIPrimitives consoleUI = new ConsoleUIPrimitives(console);

            consoleUI.DrawBox(32, 100, 2, 20);

            consoleInput.ReadInput();
            
            Environment.Exit(0);
        }
    }
}
