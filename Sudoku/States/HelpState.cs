namespace Sudoku.States
{
    using Interfaces;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class HelpState : IState
    {
        private readonly IState callerState;

        public HelpState(IState callerState)
        {
            this.callerState = callerState;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            throw new System.NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }

        public void LoadButtons()
        {
            throw new System.NotImplementedException();
        }
    }
}
