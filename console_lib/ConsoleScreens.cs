using System;
using System.Collections.Generic;
using System.IO;

namespace core_console_lib
{
    public class ConsoleScreens
    {
        List<ConsoleScreen> _screens = new List<ConsoleScreen>();
        ConsoleObj _console;

        public void LoadScreens(string screensDirectory, ConsoleObj console)        
        {
            string [] screensFiles = Directory.GetFiles(screensDirectory, "*.yaml");
            _console = console;

            foreach(string screenFile in screensFiles) 
            {
                ConsoleScreen screen = new ConsoleScreen();
                screen.LoadScreen(screenFile);
                _screens.Add(screen);
            }
        }
        public void RenderScreen(string screenName)        
        {
            ConsoleScreenRenderer renderer = new ConsoleScreenRenderer();
            ConsoleScreen screen = this.GetScreen(screenName);
            if(screen != null) 
            {
                foreach(ConsoleUIElement element in screen.Elements) 
                {
                    renderer.RenderUIElement(element, _console);
                }                    
            }
        }
        
        public void UpdateFieldValue(string screenName, string fieldName, dynamic value)
        {
            ConsoleScreenRenderer renderer = new ConsoleScreenRenderer();
            ConsoleScreen screen = this.GetScreen(screenName);

            if(screen != null) 
            {
                ConsoleUIElement element = this.GetScreenElement(screenName, fieldName);
                element.Value = value;
                renderer.RenderUIElement(element, _console);
            }
        }        

        public void UpdateFieldText(string screenName, string fieldName, string text)        
        {
            ConsoleScreenRenderer renderer = new ConsoleScreenRenderer();
            ConsoleScreen screen = this.GetScreen(screenName);

            if(screen != null) 
            {
                ConsoleUIElement element = this.GetScreenElement(screenName, fieldName);
                int lenght = element.Text.Length;
                element.Text = ConsoleUIPrimitives.GetRepeatedChars(" ", lenght);
                renderer.RenderUIElement(element, _console);
                element.Text = text;
                renderer.RenderUIElement(element, _console);
            }
        }        

        private ConsoleScreen GetScreen(string screenName) 
        {
            foreach(ConsoleScreen screen in _screens)
            {
                if(screen.Name == screenName) 
                {
                    return screen;
                }
            }

            return null;
        }
        private ConsoleUIElement GetScreenElement(string screenName, string elementName) 
        {
            ConsoleScreen screen = this.GetScreen(screenName);

            foreach(ConsoleUIElement element in screen.Elements) 
            {
                if(element.Name == elementName) 
                {
                    return element;
                }
            }                    

return null;
        }
    }
}
