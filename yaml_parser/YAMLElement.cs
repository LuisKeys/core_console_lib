using System;
using System.Collections.Generic;

namespace core_console_lib
{
    public class  YAMLElement
    {

        private string _name = "";
        private List<YAMLProperty> _properties = new List<YAMLProperty>();

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public void AddProperty(YAMLProperty property) 
        {
            _properties.Add(property);
        }

        public List<YAMLProperty> GetProperties() 
        {
            return _properties;
        }

        public YAMLElement Clone() 
        {
            YAMLElement yamlElement = new YAMLElement();
            foreach(YAMLProperty property in this._properties) 
            {
                yamlElement.AddProperty(property.Clone());
            }

            yamlElement.Name = _name;

            return yamlElement;
        }

        public string GetElementLineValue(string line)
        {
            string cleanLine = line.Replace(YAMLDocument.ELEMENT_MARKER, "").Trim();
            
            return(cleanLine);
        }

        public string GetPropertyValue(string propertyName)
        {
            foreach(YAMLProperty property in _properties) 
            {
                if(property.Name == propertyName) 
                {
                    return property.Value;
                }
            }
            
            return null;
        }
    }
}
