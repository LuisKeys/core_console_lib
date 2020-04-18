using System;

namespace core_console_lib
{
    public class ConsoleUIElement
    {
        public static string BACKGROUND_COLOR = "background_color";
        public static string COLUMN = "column";
        public static string FONT_COLOR = "font_color";
        public static string NAME = "name";
        public static string ROW = "row";
        public static string TEXT = "text";
        public static string VALUE = "value";
        private ConsoleColor _backgroundColor = ConsoleColor.Cyan;
        private int _column = 0;
        private ConsoleColor _fontColor = ConsoleColor.Cyan;
        private string _name = "";
        private int _row = 0;
        private string _text = "";
        private bool _valueBool = false;
        private double _valueDbl = 0.0;
        private int _valueInt = 0;
        private string _valueStr = "";
        private ConsoleUIElementTypes _type = ConsoleUIElementTypes.NONE;
        private ConsoleValueTypes _valueType = ConsoleValueTypes.NONE;        

        public ConsoleUIElement(string name, string type, string column, string row, string text, string value, string fontColor, string backgrounColor)
        {
            _name = name;
            _column = Convert.ToInt32(column);
            _row = Convert.ToInt32(row);
            _text = text;
            this.SetType(type);
            _fontColor = this.GetConsoleColor(fontColor);
            _backgroundColor = this.GetConsoleColor(backgrounColor);
        }

        public void SetType(string type)
        {
            switch(type) 
            {
                case "color":
                    _type = ConsoleUIElementTypes.COLOR;
                    break;
                case "label":
                    _type = ConsoleUIElementTypes.LABEL;
                    break;
            }
        }

        public void SetValue(dynamic value, ConsoleValueTypes valueType)
        {
            switch(_valueType) 
            {
                case ConsoleValueTypes.STRING:
                    _valueStr = value;
                    break;
                case ConsoleValueTypes.BOOL:
                    _valueBool = value;
                    break;
                case ConsoleValueTypes.INT:
                    _valueInt = value;
                    break;
                case ConsoleValueTypes.DOUBLE:
                    _valueDbl = value;                                        
                    break;
            }
        }
     
        public dynamic GetValue()
        {
            dynamic value = null;
            switch(_valueType) 
            {
                case ConsoleValueTypes.STRING:
                    value = _valueStr;
                    break;
                case ConsoleValueTypes.BOOL:
                    value = _valueBool;
                    break;
                case ConsoleValueTypes.INT:
                    value = _valueInt;
                    break;
                case ConsoleValueTypes.DOUBLE:
                    value = _valueDbl;
                    break;
            }

            return value;
        }
    
        public ConsoleColor GetConsoleColor(string consoleColor) 
        {
            switch(consoleColor)
            {
                case "black": return ConsoleColor.Black;
                case "blue": return ConsoleColor.Blue;
                case "cyan": return ConsoleColor.Cyan;
                case "darkblue": return ConsoleColor.DarkBlue;
                case "darkcyan": return ConsoleColor.DarkCyan;
                case "darkgray": return ConsoleColor.DarkGray;
                case "darkgree": return ConsoleColor.DarkGreen;
                case "darkmage": return ConsoleColor.DarkMagenta;
                case "darkred": return ConsoleColor.DarkRed;
                case "darkyell": return ConsoleColor.DarkYellow;
                case "gray": return ConsoleColor.Gray;
                case "green": return ConsoleColor.Green;
                case "magenta": return ConsoleColor.Magenta;
                case "red": return ConsoleColor.Red;
                case "white": return ConsoleColor.White;
                case "yellow": return ConsoleColor.Yellow;
            }

            return ConsoleColor.Black;
        }
    }
}
