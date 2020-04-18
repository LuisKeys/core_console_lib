using System;
using System.Collections.Generic;

namespace core_console_lib
{
    public class ConsoleScreenRenderer
    {
        ConsoleObj _console;
        ConsoleUIElement _element;
        public void RenderUIElement(ConsoleUIElement element, ConsoleObj console)
        {
            _console = console;
            _element = element;            
            switch(element.Type) 
            {
                case ConsoleUIElementTypes.COLOR:                
                    this.renderColor();
                    break;
                case ConsoleUIElementTypes.LABEL:
                    this.renderLabel();
                    break;
                case ConsoleUIElementTypes.BOX:
                    this.renderBox();
                    break;
                case ConsoleUIElementTypes.TABS:
                    this.renderTabs();
                    break;
            }
        }

        private void renderColor()
        {
            _console.SetColors(_element.FontColor, _element.BackgroundColor, _element.BackgroundColor);
            _console.Clear();
        }

        private void renderLabel()
        {
            if(_element.HasColors) { this.renderColor(); }
            _console.Write(_element.Column, _element.Row, _element.Text);
        }

        private void renderBox()
        {
            if(_element.HasColors) { this.renderColor(); }
            ConsoleUIPrimitives uiPrimitives = new ConsoleUIPrimitives(_console);
            int columnTo = _element.Column + _element.Width - 1;
            int rowTo = _element.Row + _element.Height - 1;
            uiPrimitives.DrawBox(_element.Column, columnTo, _element.Row, rowTo);
        }

        private void renderTabs()
        {
            ConsoleUIPrimitives uiPrimitives = new ConsoleUIPrimitives(_console);
            string [] optionsCentered = new String[_element.Options.Length];
            int optionWidth = uiPrimitives.GetListElementWidth(_element);

            for(int i = 0; i < _element.Options.Length; i++) 
            {
                optionsCentered[i] = uiPrimitives.PadStringCentered(_element.Options[i], optionWidth);
                _console.SetFontColor(_element.NonSelectedColor);
                if(i == _element.Value) 
                {
                    _console.SetFontColor(_element.SelectedColor);
                }
                _console.Write(optionWidth * i, _element.Row, optionsCentered[i]);
            }
        }        
    }
}
