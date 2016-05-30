namespace Sudoku.Exceptions
{
    using System;

    public class InvalidSudokuCombinationException : Exception
    {
        public InvalidSudokuCombinationException(string message)
            : base(message)
        {            
        }
    }
}
