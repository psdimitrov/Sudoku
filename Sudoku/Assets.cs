namespace Sudoku
{
    using Microsoft.Xna.Framework.Graphics;

    public static class Assets
    {
        public static Texture2D MainMenuTexture;
        public static Texture2D GameStateTexture;
        public static Texture2D[] Digits;

        public static Texture2D ButtonPlayHighlighted;
        public static Texture2D ButtonPlay;
        public static Texture2D ButtonSolve;
        public static Texture2D ButtonSolveHighlighted;
        public static Texture2D ButtonHelp;
        public static Texture2D ButtonHelpHighlighted;
        public static Texture2D ButtonAbout;
        public static Texture2D ButtonAboutHighlighted;        

        public static void Initialize(GameEngine game)
        {
            MainMenuTexture = game.Content.Load<Texture2D>("mainMenu");
            GameStateTexture = game.Content.Load<Texture2D>("GameStateClear");
            ButtonPlayHighlighted = game.Content.Load<Texture2D>("ButtonPlayHighLighted");
            ButtonPlay = game.Content.Load<Texture2D>("ButtonPlay");
            ButtonSolveHighlighted = game.Content.Load<Texture2D>("ButtonSolveHighLighted");
            ButtonSolve = game.Content.Load<Texture2D>("ButtonSolve");
            ButtonHelpHighlighted = game.Content.Load<Texture2D>("ButtonHelpHighLighted");
            ButtonHelp = game.Content.Load<Texture2D>("ButtonHelp");
            ButtonAboutHighlighted = game.Content.Load<Texture2D>("ButtonAboutHighLighted");
            ButtonAbout = game.Content.Load<Texture2D>("ButtonAbout");
            Digits = new Texture2D[9];

            for (int i = 1; i <= 9; i++)
            {
                Digits[i - 1] = game.Content.Load<Texture2D>("Digit" + i);
            }
        }
    }
}
