namespace Sudoku.States
{
    using Interfaces;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using Events;

    public abstract class State : IState
    {        
        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void Update(GameTime gameTime);

        public abstract void LoadButtons();
    }
}
