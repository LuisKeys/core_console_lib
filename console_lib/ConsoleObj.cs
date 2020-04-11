using System;
using System.Collections.Generic;
using System.Text;

namespace core_console_lib
{
    public class ConsoleObj
    {
        private int _columns = 132;
        private int _rows = 40;

        private List<char[]> _lines = new List<char[]>();
        public ConsoleObj() 
        {
            this.SetSize(_columns, _rows);
            this.InitBuffer();
        }

        public ConsoleObj(int columns, int rows) 
        {
            this.SetSize(columns, rows);
        }

        public void SetSize(int columns, int rows)
        {
            this.Clear();
            Console.SetWindowSize(columns, rows);
            _columns = columns;
            _rows = rows;
            this.InitBuffer();
        }

        public (int, int) GetSize()
        {
            return (_columns, _rows);
        }

        public bool IsValidCoord(int column, int row)
        {
            if(row < 0 || row > _rows -1) {return false;}
            if(column < 0 || column > _columns -1) {return false;}
            
            return true;
        }

        public ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void InitBuffer()
        {
            _lines.Clear();
            for(int row = 0; row < _rows; ++row)
            {
                char[] line = new char[_columns];
                for(int column = 0; column < _columns; ++column)
                {
                    line[column] = Convert.ToChar(" ");
                }

                _lines.Add(line);
            }
        }

        public char[] GetLine(int row)
        {
            return _lines[row];            
        }

        public List<char[]> GetLines()
        {
            return _lines;            
        }

        public void SetLine(int row, char[] line)
        {
            _lines[row] = line;
        }

        public void Render()
        {
            int i = 0;            
            foreach(char[] line in _lines)
            {
                StringBuilder lineSB = new StringBuilder();
                string character;
                for(int column = 0; column < _columns; column++)
                {
                    character = line[column].ToString();
                    lineSB.Append(character);
                }

                if(i == _rows - 1)
                {
                    Console.Write(lineSB.ToString());
                }                    
                else
                {
                    Console.WriteLine(lineSB.ToString());
                }                    
                    
                lineSB.Clear();
                ++i;
            }
        }
    }
}
