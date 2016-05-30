namespace Sudoku
{
    using Microsoft.Xna.Framework.Graphics;

    public static class Assets
    {
        public static Texture2D MainMenuTexture { get; private set; }
        public static Texture2D GameStateTexture { get; private set; }
        public static Texture2D SolveStateTexture { get; private set; }
        public static Texture2D[] Digits { get; private set; }
        public static Texture2D[] DigitButtons { get; private set; }
        public static Texture2D[] DigitButtonsHighlighted { get; private set; }
        public static Texture2D BackButton { get; private set; }
        public static Texture2D BackButtonHighlighted { get; private set; }
        public static Texture2D SolveButton { get; private set; }
        public static Texture2D SolveButtonHighlighted { get; private set; }
        public static Texture2D NoSolutionMessage { get; private set; }
        public static Texture2D ButtonPlayHighlighted { get; private set; }
        public static Texture2D ButtonPlay { get; private set; }
        public static Texture2D ButtonSolve { get; private set; }
        public static Texture2D ButtonSolveHighlighted { get; private set; }
        public static Texture2D ButtonHelp { get; private set; }
        public static Texture2D ButtonHelpHighlighted { get; private set; }
        public static Texture2D ButtonAbout { get; private set; }
        public static Texture2D ButtonAboutHighlighted { get; private set; }

        public static void Initialize(GameEngine game)
        {
            MainMenuTexture = game.Content.Load<Texture2D>("mainMenu");
            GameStateTexture = game.Content.Load<Texture2D>("GameStateClear");
            SolveStateTexture = game.Content.Load<Texture2D>("SolveStateClear");
            BackButton = game.Content.Load<Texture2D>("BackButton");
            BackButtonHighlighted = game.Content.Load<Texture2D>("BackButtonHighLighted");
            SolveButton = game.Content.Load<Texture2D>("SolveButton");
            SolveButtonHighlighted = game.Content.Load<Texture2D>("SolveButtonHighLighted");
            NoSolutionMessage = game.Content.Load<Texture2D>("NoSolution");
            ButtonPlayHighlighted = game.Content.Load<Texture2D>("ButtonPlayHighLighted");
            ButtonPlay = game.Content.Load<Texture2D>("ButtonPlay");
            ButtonSolveHighlighted = game.Content.Load<Texture2D>("ButtonSolveHighLighted");
            ButtonSolve = game.Content.Load<Texture2D>("ButtonSolve");
            ButtonHelpHighlighted = game.Content.Load<Texture2D>("ButtonHelpHighLighted");
            ButtonHelp = game.Content.Load<Texture2D>("ButtonHelp");
            ButtonAboutHighlighted = game.Content.Load<Texture2D>("ButtonAboutHighLighted");
            ButtonAbout = game.Content.Load<Texture2D>("ButtonAbout");

            Digits = new Texture2D[9];
            for (int i = 0; i < 9; i++)
            {
                Digits[i] = game.Content.Load<Texture2D>("Digit" + (i + 1));
            }
       
            DigitButtons = new Texture2D[9];
            for (int i = 0; i < 9; i++)
            {
                DigitButtons[i] = game.Content.Load<Texture2D>("ButtonDigit" + (i + 1));
            }

            DigitButtonsHighlighted = new Texture2D[9];
            for (int i = 0; i < 9; i++)
            {
                DigitButtonsHighlighted[i] = game.Content.Load<Texture2D>("ButtonDigit" + (i + 1) + "HighLighted");
            }
        }
    }
}
