using System;
using System.Collections.Generic;
using System.IO;

namespace core_console_lib
{
    public class ConsoleObj
    {
        private int _columns = 132;
        private int _rows = 43;

        private ConsoleColor _fontColor = ConsoleColor.DarkYellow;
        private ConsoleColor _fontBackColor = ConsoleColor.Black;
        private ConsoleColor _backgroundColor = ConsoleColor.Black;
        private bool _isWindows = true;

        public ConsoleObj() 
        {
            this.IsWindows();
            this.SetSize(_columns, _rows);
            this.SetColors(_fontColor, _fontBackColor, _backgroundColor);
            this.SendCursorToBottom();
        }

        public ConsoleObj(int columns, int rows, ConsoleColor fontColor, ConsoleColor fontBackColor, ConsoleColor backgroundColor) 
        {
            this.IsWindows();
            this.SetSize(columns, rows);
            this.SetColors(fontColor, fontBackColor, backgroundColor);
        }

        public void SetColors(ConsoleColor fontColor, ConsoleColor fontBackColor)
        {
            _fontColor = fontColor;
            _fontBackColor = fontBackColor;
            Console.ForegroundColor = _fontColor;
            Console.BackgroundColor = _fontBackColor;
        }

        public void SetColors(ConsoleColor fontColor, ConsoleColor fontBackColor, ConsoleColor backgroundColor)
        {
            _fontColor = fontColor;
            _fontBackColor = fontBackColor;
            _backgroundColor = backgroundColor;
            Console.ForegroundColor = _fontColor;
            Console.BackgroundColor = _backgroundColor;
        }

        public void SetSize(int columns, int rows)
        {
            this.Clear();
            if(_isWindows){
                Console.SetWindowSize(columns, rows + 1);
            }                

            _columns = columns;
            _rows = rows;
        }

        public (int, int) GetSize()
        {
            return (_columns, _rows);
        }

        public (ConsoleColor, ConsoleColor) GetColors()
        {
            return (_fontColor, _backgroundColor);
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

        public void SetCursorPosition(int column, int row) 
        {
            Console.SetCursorPosition(column, row);
        }
       
        public void Write(int column, int row, string text) 
        {
            this.SetCursorPosition(column, row);
            Console.Write(text);
        }

        public void SendCursorToBottom() 
        {
            Console.ForegroundColor = _backgroundColor;
            Console.BackgroundColor = _backgroundColor;
            this.Write(1, _rows - 1, " ");
            Console.ForegroundColor = _fontColor;
            Console.BackgroundColor = _fontBackColor;
            Console.CursorVisible = false;
        }

        private bool IsWindows()
        {            
            string windir = Environment.GetEnvironmentVariable("windir");
            if (!string.IsNullOrEmpty(windir) && windir.Contains(@"\") && Directory.Exists(windir))
            {
                _isWindows = true;
                return true;
            }

            _isWindows = false;
            return false;
        }
    }
}

