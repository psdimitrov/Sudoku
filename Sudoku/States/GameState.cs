namespace Sudoku.States
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class GameState : State
    {
        private Rectangle digit1Area;
        private Rectangle digit2Area;
        private Rectangle digit3Area;
        private Rectangle digit4Area;
        private Rectangle digit5Area;
        private Rectangle digit6Area;
        private Rectangle digit7Area;
        private Rectangle digit8Area;
        private Rectangle digit9Area;

        public GameState()
        {
            this.digit1Area = new Rectangle(0, 549, 41, 46);
            this.digit2Area = new Rectangle(42, 559, 50, 44);
            this.digit3Area = new Rectangle(95, 565, 36, 46);
            this.digit4Area = new Rectangle(134, 559, 41, 49);
            this.digit5Area = new Rectangle(177, 551, 43, 45);
            this.digit6Area = new Rectangle(222, 555, 46, 48);
            this.digit7Area = new Rectangle(271, 546, 38, 47);
            this.digit8Area = new Rectangle(312, 565, 42, 45);
            this.digit9Area = new Rectangle(358, 549, 42, 46);
        }

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
