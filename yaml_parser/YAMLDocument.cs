using System;
using System.Collections.Generic;

namespace core_console_lib
{    
    public class YAMLDocument
    {
        private List<YAMLObject> _objects = new List<YAMLObject>();

        public void addObject(YAMLObject yamlObject) 
        {
            _objects.Add(yamlObject);
        }        

        public List<YAMLObject> GetObjects() 
        {
            return _objects;
        }
    }
}
