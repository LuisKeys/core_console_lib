using System;
using System.Collections.Generic;

namespace core_console_lib
{
    public class ConsoleScreen
    {
        List<ConsoleUIElement> _elements = new List<ConsoleUIElement>();
        
        public void LoadScreen(string screenFileName)
        {
            YAMLReader reader = new YAMLReader();            
            YAMLDocument document = reader.Read(screenFileName);
            if(document != null) 
            {
                this.getUIElements(document);
            }
        }

        private void getUIElements(YAMLDocument document)
        {
            foreach(YAMLElement yamlElement in document.GetElements()) 
            {
                string name = yamlElement.GetPropertyValue(ConsoleUIElement.NAME);
                string type = yamlElement.Name;
                string column = yamlElement.GetPropertyValue(ConsoleUIElement.COLUMN);
                string row = yamlElement.GetPropertyValue(ConsoleUIElement.ROW);
                string text = yamlElement.GetPropertyValue(ConsoleUIElement.TEXT);
                string value = yamlElement.GetPropertyValue(ConsoleUIElement.VALUE);
                string fontColor = yamlElement.GetPropertyValue(ConsoleUIElement.FONT_COLOR);
                string backgrounColor = yamlElement.GetPropertyValue(ConsoleUIElement.BACKGROUND_COLOR);

                ConsoleUIElement element = new ConsoleUIElement(name, type, column, row, text, value, fontColor, backgrounColor);
                _elements.Add(element);
            }
        }
    }
}
