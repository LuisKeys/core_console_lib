using System;

namespace core_console_lib
{
    public class  YAMLProperty
    {
        private string _name;
        private dynamic _value;
        public YAMLProperty(string name, dynamic value) 
        {
            _name = name;
            _value = value;            
        }         

        public (string, dynamic) GetProperty() {
            return (_name, _value);
        }
    }
}
