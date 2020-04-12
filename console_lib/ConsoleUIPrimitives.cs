using System;
using System.Collections.Generic;
using System.Text;

namespace core_console_lib
{
    public class ConsoleUIPrimitives
    {
        private ConsoleObj _console;

        private string _horizLineCharacter = "=";
        private string _vertLineCharacter = "|";

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
            this.DrawHorizLine(rowFrom, columnFrom, columnTo);
            this.DrawHorizLine(rowTo, columnFrom, columnTo);
            this.DrawVertLine(columnFrom, rowFrom, rowTo);
            this.DrawVertLine(columnTo, rowFrom, rowTo);
        }
    }
}
