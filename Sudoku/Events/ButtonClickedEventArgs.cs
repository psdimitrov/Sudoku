namespace Sudoku.Events
{
    using System;

    public class ButtonClickedEventArgs : EventArgs
    {
        public ButtonClickedEventArgs(ButtonNames button)
        {
            this.Button = button;
        }

        public ButtonNames Button { get; set; }
    }
}
