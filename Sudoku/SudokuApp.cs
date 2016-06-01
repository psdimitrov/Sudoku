using System;

namespace Sudoku
{
    using Core;

#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class SudokuApp
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new GameEngine())
            {
                game.Run();                
            }
        }
    }
#endif
}
