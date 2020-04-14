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
                string name = "";
                string type = yamlElement.Name;
                string column = "0";
                string row = "0";
                string text = "";
                string value = "";

                ConsoleUIElement element = new ConsoleUIElement(name, type, column, row, text, value);
                _elements.Add(element);
            }
        }
    }
}
