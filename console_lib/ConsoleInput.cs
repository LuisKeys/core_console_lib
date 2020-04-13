using System;
using System.Threading;

namespace core_console_lib
{
    public class ConsoleInput
    {
        ConsoleObj _console;
        public ConsoleInput(ConsoleObj console)
        {
            _console = console;
        }

        public ConsoleKeyInfo ReadInput() 
        {
            _console.SendCursorToBottom();
            
            while (!Console.KeyAvailable) {
                Thread.Sleep(10);
            };            

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            _console.SendCursorToBottom();

            return keyInfo;
        }
    }
}

