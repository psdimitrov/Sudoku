namespace Sudoku.Interfaces
{
    public interface IState : IDrawable, IUpdateable
    {
        void LoadButtons();
    }
}
