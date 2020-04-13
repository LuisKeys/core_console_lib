using System;
using System.Collections.Generic;

namespace core_console_lib
{
    public class  YAMLObject
    {
        private List<YAMLProperty> _properties = new List<YAMLProperty>();

        public void addProperty(YAMLProperty property) 
        {
            _properties.Add(property);
        }

        public List<YAMLProperty> GetProperties() 
        {
            return _properties;
        }
    }
}
