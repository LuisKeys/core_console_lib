using System;
using System.Collections.Generic;
using System.IO;

namespace core_console_lib
{
    public class ConsoleScreen
    {
        string _name;
        List<ConsoleUIElement> _elements = new List<ConsoleUIElement>();

        public string Name
        {
            get{ return _name; }
        }
        
        public List<ConsoleUIElement> Elements
        {
            get{ return _elements; }
        }
 
        public void LoadScreen(string screenFileName)
        {
            _name = Path.GetFileNameWithoutExtension(screenFileName);
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
                ConsoleUIElementParam param = new ConsoleUIElementParam();
                param.Name = yamlElement.GetPropertyValue(ConsoleUIElement.NAME);
                param.Type = yamlElement.Name;
                param.Column = yamlElement.GetPropertyValue(ConsoleUIElement.COLUMN);
                param.Row = yamlElement.GetPropertyValue(ConsoleUIElement.ROW);
                param.Height = yamlElement.GetPropertyValue(ConsoleUIElement.HEIGHT);
                param.Width = yamlElement.GetPropertyValue(ConsoleUIElement.WIDTH);
                param.Text = yamlElement.GetPropertyValue(ConsoleUIElement.TEXT);
                param.Value = yamlElement.GetPropertyValue(ConsoleUIElement.VALUE);
                param.FontColor = yamlElement.GetPropertyValue(ConsoleUIElement.FONT_COLOR);
                param.BackgrounColor = yamlElement.GetPropertyValue(ConsoleUIElement.BACKGROUND_COLOR);
                param.Options = yamlElement.GetPropertyValue(ConsoleUIElement.BACKGROUND_COLOR);
                param.SelectedColor = yamlElement.GetPropertyValue(ConsoleUIElement.SELECTED_COLOR);
                param.NonSelectedColor = yamlElement.GetPropertyValue(ConsoleUIElement.NON_SELECTED_COLOR);
                param.Options = yamlElement.GetPropertyValue(ConsoleUIElement.OPTIONS);

                ConsoleUIElement element = new ConsoleUIElement(param);
                _elements.Add(element);
            }
        }
    }
}
