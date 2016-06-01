namespace Sudoku.Core
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    using Events;
    using States;

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameEngine : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public GameEngine()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            this.graphics.PreferredBackBufferHeight = 652;
            this.graphics.PreferredBackBufferWidth = 400;
            this.graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            MainMenuState menu = new MainMenuState();
            menu.ButtonClicked += this.MainMenu_ButtonClicked;
            StateManager.CurrentState = menu;
            this.IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);            
            Assets.Initialize(this);
            StateManager.CurrentState.LoadButtons();
            
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) this.Exit();

            // TODO: Add your update logic here
            if (StateManager.CurrentState != null)
            {
                StateManager.CurrentState.Update(gameTime);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.White);

            if (StateManager.CurrentState != null)
            {
                StateManager.CurrentState.Draw(this.spriteBatch);
            }

            base.Draw(gameTime);
        }

        private void MainMenu_ButtonClicked(object sender, ButtonClickedEventArgs eventargs)
        {
            switch (eventargs.Button)
            {
                case ButtonNames.Play:
                    var newGameState = new GameState(StateManager.CurrentState);
                    newGameState.LoadButtons();
                    StateManager.CurrentState = newGameState;                    
                    break;
                case ButtonNames.Solve:
                    var newSolveState = new SolveState(StateManager.CurrentState);
                    newSolveState.LoadButtons();
                    StateManager.CurrentState = newSolveState;
                    break;
                case ButtonNames.Help:
                    var newHelpState = new HelpState(StateManager.CurrentState);
                    newHelpState.LoadButtons();
                    StateManager.CurrentState = newHelpState;
                    break;
                case ButtonNames.About:
                    var newAboutState = new AboutState(StateManager.CurrentState);
                    newAboutState.LoadButtons();
                    StateManager.CurrentState = newAboutState;
                    break;
            }
        }
    }    
}
