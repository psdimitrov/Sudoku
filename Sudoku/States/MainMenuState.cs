namespace Sudoku.States
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    using GameObjects;

    using Events;
    using Interfaces;

    public class MainMenuState : IState
    {
        public event ButtonClickedEventHandler ButtonClicked;

        private Rectangle buttonPlayArea;
        private Rectangle buttonSolveArea;        
        private Rectangle buttonHelpArea;
        private Rectangle buttonAboutArea;

        private Button playButton;
        private Button solveButton;
        private Button helpButton;
        private Button aboutButton;

        private GameTime time;

        public MainMenuState()
        {
            this.buttonPlayArea = new Rectangle(240, 270, 80, 50);         
            this.buttonSolveArea = new Rectangle(230, 335, 95, 40);         
            this.buttonHelpArea = new Rectangle(235, 395, 80, 50);         
            this.buttonAboutArea = new Rectangle(230, 455, 100, 35);         
        }

        public void LoadButtons()
        {
            this.playButton = new Button(Assets.ButtonPlay, Assets.ButtonPlayHighlighted, new Vector2(240, 270));
            this.solveButton = new Button(Assets.ButtonSolve, Assets.ButtonSolveHighlighted, new Vector2(230, 335));
            this.helpButton = new Button(Assets.ButtonHelp, Assets.ButtonHelpHighlighted, new Vector2(235, 395));
            this.aboutButton = new Button(Assets.ButtonAbout, Assets.ButtonAboutHighlighted, new Vector2(220, 450));
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Assets.MainMenuTexture, Vector2.Zero);
            this.playButton.Draw(gameTime, spriteBatch);
            this.solveButton.Draw(gameTime, spriteBatch);
            this.helpButton.Draw(gameTime, spriteBatch);
            this.aboutButton.Draw(gameTime, spriteBatch);                
            spriteBatch.End();
        }

        public void Update(GameTime gameTime)
        {
            this.playButton.IsHighlighted = this.buttonPlayArea.Contains(Mouse.GetState().Position);
            this.solveButton.IsHighlighted = this.buttonSolveArea.Contains(Mouse.GetState().Position);
            this.helpButton.IsHighlighted = this.buttonHelpArea.Contains(Mouse.GetState().Position);
            this.aboutButton.IsHighlighted = this.buttonAboutArea.Contains(Mouse.GetState().Position);

            if (this.buttonPlayArea.Contains(Mouse.GetState().Position)
                && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                this.OnButtonClicked(ButtonNames.Play);
            }

            if (this.buttonSolveArea.Contains(Mouse.GetState().Position)
                && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                this.OnButtonClicked(ButtonNames.Solve);
            }

            if (this.buttonAboutArea.Contains(Mouse.GetState().Position)
                && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                this.OnButtonClicked(ButtonNames.About);
            }

            this.time = gameTime;
        }

        private void OnButtonClicked(ButtonNames button)
        {
            if (this.ButtonClicked != null)
            {
                ButtonClickedEventArgs args = new ButtonClickedEventArgs(button, this.time);
                this.ButtonClicked(this, args);
            }
        }
    }
}
