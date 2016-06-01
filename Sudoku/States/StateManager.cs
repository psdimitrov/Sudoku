namespace Sudoku.States
{
    using Interfaces;

    public class StateManager
    {
        public static IState CurrentState { get; set; }
    }
}
