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

        public YAMLProperty(string line) 
        {
            (_name, _value) = this.ParseProperty(line);            
        }         

        public (string, dynamic) GetProperty() {
            return (_name, _value);
        }

        private (string, dynamic) ParseProperty(string line) 
        {
            if(line.IndexOf(YAMLDocument.PROPERTY_SPLITTER) > -1) 
            {
                string name = line.Split(YAMLDocument.PROPERTY_SPLITTER)[0];
                dynamic value = line.Split(YAMLDocument.PROPERTY_SPLITTER)[1];
                return(name, value);
            }
            return(null, null);
        }

        public YAMLProperty Clone() 
        {
            return new YAMLProperty(_name, _value);
        }
    }
}
