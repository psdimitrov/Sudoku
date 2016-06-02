namespace Sudoku.Events
{
    using System;

    using Microsoft.Xna.Framework;

    public class ButtonClickedEventArgs : EventArgs
    {
        public ButtonClickedEventArgs(ButtonNames button, GameTime time)
        {
            this.Button = button;
            this.Time = time;
        }

        public ButtonNames Button { get; set; }
        public GameTime Time { get; set; }
    }
}
