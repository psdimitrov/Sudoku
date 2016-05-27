namespace Sudoku.States
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class GameState : State
    {
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Assets.GameStateTexture, Vector2.Zero);
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void LoadButtons()
        {
            throw new System.NotImplementedException();
        }
    }
}
