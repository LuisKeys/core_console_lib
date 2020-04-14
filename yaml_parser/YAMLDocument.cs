using System;
using System.Collections.Generic;

namespace core_console_lib
{    
    public class YAMLDocument
    {
        private List<YAMLElement> _elements = new List<YAMLElement>();
        public const string FEED_ELEMENT_START = "---";
        public const string FEED_ELEMENT_END = "...";
        public const string PROPERTY_SPLITTER = ": ";
        public const string ELEMENT_MARKER = "- !";
        public const string DOCUMENT_MARKER = "--- !";
        public const string COMMENT_MARKER = "# ";
        public const string SCREEN_KEYWORD = "screen";

        public void AddElement(YAMLElement yamlElement) 
        {
            _elements.Add(yamlElement);
        }        

        public List<YAMLElement> GetElements() 
        {
            return _elements;
        }

        public static string GetDocumentLineValue(string line) 
        {
            string cleanLine = line.Replace(YAMLDocument.DOCUMENT_MARKER, "").Trim();
            return(cleanLine);
        }
    }
}
