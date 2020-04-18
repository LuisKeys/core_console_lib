using System;

namespace core_console_lib
{
    public class  YAMLProperty
    {
        private string _name;
        private string _value;

        public string Name
        {
            get { return _name; }
            set { _name = value;}
        }

        public string Value
        {
            get { return _value; }
            set { _value = value;}
        }

           public YAMLProperty(string name, dynamic value) 
        {
            _name = name;
            _value = value;            
        }         

        public YAMLProperty(string line) 
        {
            (_name, _value) = this.ParseProperty(line);            
        }         

        public (string, string) GetProperty() {
            return (_name, _value);
        }

        private (string, string) ParseProperty(string line) 
        {
            if(line.IndexOf(YAMLDocument.PROPERTY_SPLITTER) > -1) 
            {
                string name = line.Split(YAMLDocument.PROPERTY_SPLITTER)[0];
                string value = line.Split(YAMLDocument.PROPERTY_SPLITTER)[1];
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
