using System;
using System.Collections.Generic;

namespace core_console_lib
{
    public class ConsoleUIPrimitives
    {
        ConsoleObj _console;
        int _columns;
        int _rows;

        string _horizLineCharacter = "_";

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

            (_columns, _rows) = _console.GetSize();            
            char[] line = _console.GetLine(row);
            for(int column = columnFrom; column <= columnTo; column++)
            {
                line[column] = Convert.ToChar(character);
            }
            _console.SetLine(row, line);
        }
    }
}
