using System;

namespace core_console_lib
{
    public class ConsoleUIElement
    {
        public static string BACKGROUND_COLOR = "background_color";
        public static string COLUMN = "column";
        public static string FONT_COLOR = "font_color";
        public static string HEIGHT = "height";
        public static string NAME = "name";
        public static string ROW = "row";
        public static string OPTIONS = "options";
        public static string SELECTED_COLOR = "selected_color";
        public static string NON_SELECTED_COLOR = "non_selected_color";
        public static string TEXT = "text";
        public static string VALUE = "value";
        public static string WIDTH = "width";
        private ConsoleColor _backgroundColor = ConsoleColor.Black;
        private int _column = 0;
        private ConsoleColor _fontColor = ConsoleColor.Cyan;
        private bool _hasColors = false; 
        private int _height = 0; 
        private string _name = "";
        private ConsoleColor _nonSelectedColor = ConsoleColor.DarkYellow;
        private string [] _options;
        private int _row = 0;
        private ConsoleColor _selectedColor = ConsoleColor.Yellow;
        private string _text = "";
        private int _width = 0; 
        private ConsoleUIElementTypes _type = ConsoleUIElementTypes.NONE;
        private ConsoleValueTypes _valueType = ConsoleValueTypes.NONE;
        private dynamic _value;

        public ConsoleUIElementTypes Type
        {
            get { return _type; }
        }

        public string Name
        {
            get { return _name; }
        }

        public int Column
        {
            get { return _column; }
        }

        public int Row
        {
            get { return _row; }
        }

        public dynamic Value
        {
            get { return _value; }
            set { _value  = value; }
        }

        public int Height
        {
            get { return _height; }
        }

        public int Width
        {
            get { return _width; }
        }
        public string Text

        {
            get { return _text; }
            set { _text = value; }
        }

        public ConsoleColor FontColor
        {
            get { return _fontColor; }
        }

        public ConsoleColor BackgroundColor
        {
            get { return _backgroundColor; }
        }

        public bool HasColors
        {
            get { return _hasColors; }
        }

        public ConsoleColor SelectedColor
        {
            get { return _selectedColor; }
        }

        public ConsoleColor NonSelectedColor
        {
            get { return _nonSelectedColor; }
        }

        public string [] Options
        {
            get { return _options; }
        }

        public ConsoleUIElement(ConsoleUIElementParam param)
        {
            _name = param.Name;
            _column = Convert.ToInt32(param.Column);
            _row = Convert.ToInt32(param.Row);
            _height = Convert.ToInt32(param.Height);
            _width = Convert.ToInt32(param.Width);
            _text = param.Text;
            this.SetType(param.Type);
            _fontColor = this.GetConsoleColor(param.FontColor);
            _backgroundColor = this.GetConsoleColor(param.BackgrounColor);
            _selectedColor = this.GetConsoleColor(param.SelectedColor);
            _nonSelectedColor = this.GetConsoleColor(param.NonSelectedColor);

            if(param.Options != null)
            {
                _options = param.Options.Split(",");
                for(int i = 0; i < _options.Length; i++) 
                {
                    _options[i] = _options[i].Trim();
                }
            }

            _value = Convert.ToInt32(param.Value);
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
                case "box":
                    _type = ConsoleUIElementTypes.BOX;
                    break;
                case "tabs":
                    _type = ConsoleUIElementTypes.TABS;
                    break;
            }
        }
    
    public ConsoleColor GetConsoleColor(string consoleColor) 
        {
            _hasColors = true;
            switch(consoleColor)
            {
                case "black": return ConsoleColor.Black;
                case "blue": return ConsoleColor.Blue;
                case "cyan": return ConsoleColor.Cyan;
                case "darkblue": return ConsoleColor.DarkBlue;
                case "darkcyan": return ConsoleColor.DarkCyan;
                case "darkgray": return ConsoleColor.DarkGray;
                case "darkgreen": return ConsoleColor.DarkGreen;
                case "darkmagenta": return ConsoleColor.DarkMagenta;
                case "darkred": return ConsoleColor.DarkRed;
                case "darkyellow": return ConsoleColor.DarkYellow;
                case "gray": return ConsoleColor.Gray;
                case "green": return ConsoleColor.Green;
                case "magenta": return ConsoleColor.Magenta;
                case "red": return ConsoleColor.Red;
                case "white": return ConsoleColor.White;
                case "yellow": return ConsoleColor.Yellow;
            }

            _hasColors = false;
            return ConsoleColor.Black;
        }
    }
}
