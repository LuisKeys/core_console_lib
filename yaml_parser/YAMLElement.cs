using System;
using System.Collections.Generic;

namespace core_console_lib
{
    public class  YAMLElement
    {

        private string _name = "";
        private List<YAMLProperty> _properties = new List<YAMLProperty>();

        public void SetName(string name) 
        {
            _name = name;
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

            yamlElement.SetName(_name);

            return yamlElement;
        }

        public string GetElementLineValue(string line)
        {
            string cleanLine = line.Replace(YAMLDocument.ELEMENT_MARKER, "").Trim();
            
            return(cleanLine);
        }
    }
}
