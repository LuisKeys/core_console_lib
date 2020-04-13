using System;

namespace core_console_lib
{
    public class ConsoleField
    {
        private string _name = "";
        private string _valueStr = "";
        private bool _valueBool = false;
        private int _valueInt = 0;
        private double _valueDbl = 0.0;
        private ConsoleFieldType _type = ConsoleFieldType.NONE;
        public ConsoleField(string name, dynamic value, ConsoleFieldType type)
        {
            _name = name;
            this.SetValue(value, type);
        }

        public void SetValue(dynamic value, ConsoleFieldType type)
        {
            switch(type) 
            {
                case ConsoleFieldType.STRING:
                    _valueStr = value;
                    break;
                case ConsoleFieldType.BOOL:
                    _valueBool = value;
                    break;
                case ConsoleFieldType.INT:
                    _valueInt = value;
                    break;
                case ConsoleFieldType.DOUBLE:
                    _valueDbl = value;                                        
                    break;
            }
        }
        public dynamic GetValue()
        {
            dynamic value = null;
            switch(_type) 
            {
                case ConsoleFieldType.STRING:
                    value = _valueStr;
                    break;
                case ConsoleFieldType.BOOL:
                    value = _valueBool;
                    break;
                case ConsoleFieldType.INT:
                    value = _valueInt;
                    break;
                case ConsoleFieldType.DOUBLE:
                    value = _valueDbl;
                    break;
            }

            return value;
        }
    }
}
