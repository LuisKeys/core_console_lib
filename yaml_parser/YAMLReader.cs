using System;
using System.Collections.Generic;
using System.IO;

namespace core_console_lib
{
    public class  YAMLReader
    {
        private List<string> _lines = new List<string>();
        private YAMLDocument _document = new YAMLDocument();
        
        public YAMLDocument Read(string documentFile) 
        {
             this.readFile(documentFile);
             return this.parse();
        }         

        private YAMLDocument parse() 
        {
            YAMLDocument yamlDocument = null;
            YAMLElement yamlElement = null;
            foreach(string line in _lines) 
            {
                if(yamlDocument != null) 
                {
                    if(line.IndexOf(YAMLDocument.PROPERTY_SPLITTER) > -1 && yamlElement != null)
                    {
                        YAMLProperty property = new YAMLProperty(line);
                        yamlElement.AddProperty(property);
                    }

                    if(line.StartsWith(YAMLDocument.ELEMENT_MARKER))
                    {
                        if(yamlElement != null) 
                        {
                            yamlDocument.AddElement(yamlElement.Clone());
                        }
                        
                        yamlElement = new YAMLElement();

                        yamlElement.Name = yamlElement.GetElementLineValue(line);
                    }
                }

                if(line.StartsWith(YAMLDocument.DOCUMENT_MARKER))
                {
                    if(YAMLDocument.GetDocumentLineValue(line) == YAMLDocument.SCREEN_KEYWORD) 
                    {
                        yamlDocument = new YAMLDocument();
                    }
                }
            }

            if(yamlElement != null) 
            {
                yamlDocument.AddElement(yamlElement.Clone());
            }            

            return yamlDocument;
        }

        private void readFile(string documentFile) 
        {
            string line;            
            StreamReader fileReader = new StreamReader(documentFile);
            _lines.Clear();

            while((line = fileReader.ReadLine()) != null) 
            {
                _lines.Add(line.Trim());
            }

            fileReader.Close();
        }
    }
}

