namespace Sudoku.States
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using Interfaces;

    using GameObjects;

    using Microsoft.Xna.Framework.Input;

    class AboutState : IState
    {
        private Rectangle backButtonArea;
        private Button backButton;

        private readonly IState callerState;

        public AboutState(IState callerState)
        {
            this.callerState = callerState;
            this.backButtonArea = new Rectangle(30, 20, 40, 18);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Assets.AboutStateTexture, Vector2.Zero);
            this.backButton.Draw(spriteBatch);
            spriteBatch.End();
        }

        public void Update(GameTime gameTime)
        {
            this.backButton.IsHighlighted = this.backButtonArea.Contains(Mouse.GetState().Position);
            if (this.backButtonArea.Contains(Mouse.GetState().Position)
                && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                StateManager.CurrentState = this.callerState;
            }
        }

        public void LoadButtons()
        {
            this.backButton = new Button(Assets.BackButtonAbout, Assets.BackButtonAboutHighlighted, new Vector2(15, 15));
        }
    }
}
