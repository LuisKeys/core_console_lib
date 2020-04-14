using System;
using System.Collections.Generic;

namespace core_console_lib
{
    public class ConsoleScreens
    {
        List<ConsoleScreen> _screens = new List<ConsoleScreen>();

        public void LoadScreen(string screenFileName)        
        {
            ConsoleScreen screen = new ConsoleScreen();
            screen.LoadScreen(screenFileName);
            _screens.Add(screen);
        }
    }
}
