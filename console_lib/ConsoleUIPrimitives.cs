using System;
using System.Collections.Generic;
using System.Text;

namespace core_console_lib
{
    public class ConsoleUIPrimitives
    {
        private ConsoleObj _console;

        private string _horizLineCharacter = "_";

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

            StringBuilder text = new StringBuilder();
            for(int column = columnFrom; column < columnTo; ++column)
            {
                text.Append(character);
            }

            _console.Write(columnFrom, row, text.ToString());

            _console.SendCursorToBottom();
        }
    }
}
