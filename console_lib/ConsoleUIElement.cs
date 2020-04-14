using System;

namespace core_console_lib
{
    public class ConsoleUIElement
    {
        private string _name = "";
        private string _text = "";
        private int _column = 0;
        private int _row = 0;
        private string _valueStr = "";
        private bool _valueBool = false;
        private int _valueInt = 0;
        private double _valueDbl = 0.0;
        private ConsoleUIElementTypes _type = ConsoleUIElementTypes.NONE;
        private ConsoleValueTypes _valueType = ConsoleValueTypes.NONE;        

        public ConsoleUIElement(string name, string type, string column, string row, string text, string value)
        {
            _name = name;
            _column = Convert.ToInt32(column);
            _row = Convert.ToInt32(row);
            _text = text;
            this.SetType(type);
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
    }
}
