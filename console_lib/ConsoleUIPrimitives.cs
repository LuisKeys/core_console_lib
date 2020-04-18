using System;
using System.Collections.Generic;
using System.Text;

namespace core_console_lib
{
    public class ConsoleUIPrimitives
    {
        private ConsoleObj _console;

        private string _horizLineCharacter = "-";
        private string _vertLineCharacter = "|";
        private string _progressBarrCharacter = "*";
        private string _boxCorner = "+";

        public ConsoleUIPrimitives(ConsoleObj console)
        {
            _console = console;
        }

        public void DrawHorizLine(int row, int columnFrom, int columnTo)
        {
            this.DrawHorizLine(row, columnFrom, columnTo, _horizLineCharacter);
        }

        public void DrawHorizLine(int row, int columnFrom, int columnTo, string character)
        {
            if(!_console.IsValidCoord(columnFrom, row)) return;
            if(!_console.IsValidCoord(columnTo, row)) return;

            if(columnFrom > columnTo)
            {
                int columnAux = columnTo;
                columnTo = columnFrom;
                columnFrom = columnAux;
            }

            _console.Write(columnFrom, row, character, columnTo - columnFrom + 1);
            _console.SendCursorToBottom();
        }

        public void DrawVertLine(int column, int rowFrom, int rowTo)
        {
            this.DrawVertLine(column, rowFrom, rowTo, _vertLineCharacter);
        }

        public void DrawVertLine(int column, int rowFrom, int rowTo, string character)
        {
            if(!_console.IsValidCoord(column, rowFrom)) return;
            if(!_console.IsValidCoord(column, rowTo)) return;

            if(rowFrom > rowTo)
            {
                int rowAux = rowTo;
                rowTo = rowFrom;
                rowFrom = rowAux;
            }

            StringBuilder text = new StringBuilder();
            for(int row = rowFrom; row <= rowTo; row++)
            {
                _console.Write(column, row, character);
            }            

            _console.SendCursorToBottom();
        }

        public void  DrawBox(int columnFrom, int columnTo, int rowFrom, int rowTo)
        {
            this._console.Write(columnFrom, rowFrom, this._boxCorner);
            this._console.Write(columnTo, rowFrom, this._boxCorner);
            this._console.Write(columnFrom, rowTo, this._boxCorner);
            this._console.Write(columnTo, rowTo, this._boxCorner);
            this.DrawHorizLine(rowFrom, columnFrom + 1, columnTo - 1);
            this.DrawHorizLine(rowTo, columnFrom + 1, columnTo - 1);
            this.DrawVertLine(columnFrom, rowFrom + 1, rowTo - 1);
            this.DrawVertLine(columnTo, rowFrom + 1, rowTo - 1);
        }

        public void DrawProgressBar(int column, int row, int lenght, int value)
        {
            this.DrawProgressBar(column, row, lenght, value, _progressBarrCharacter);
        }         

        public void DrawProgressBar(int column, int row, int lenght, int value, string character)
        {
            int valueUI = Convert.ToInt32(Convert.ToDouble(value) * Convert.ToDouble(lenght) / 100.0);
            _console.Write(column, row, " ", lenght);
            _console.Write(column, row, character, valueUI);
        }

        public static string GetRepeatedChars(string character, int lenght)        
        {
            StringBuilder text = new StringBuilder();
            for(int i = 0; i < lenght; i++) 
            {
                text.Append(character);
            }
            
            return text.ToString();
        }         

        public int GetListElementWidth(ConsoleUIElement element) 
        {
            int screenWidth = _console.GetSize().Item1;
            return Convert.ToInt32(Convert.ToDouble(screenWidth) / Convert.ToDouble(element.Options.Length));
        }

        public string PadStringCentered(string text, int length) 
        {
            int textLenght = text.Length;
            if(textLenght >= length) { return text; }
            int leftPadWidth = Convert.ToInt32(Convert.ToDouble(length - textLenght) / 2.0);
            return text.PadLeft(leftPadWidth + textLenght);
        }
    }
}
