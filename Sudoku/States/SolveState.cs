﻿namespace Sudoku.States
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    using GameObjects;

    using Core;
    using Exceptions;
    using Interfaces;

    public class SolveState : IState
    {
        private readonly IState callerState;
        private readonly Rectangle[] digitAreas;
        private Button[] digitButtons;

        private Rectangle backButtonArea;
        private Button backButton;
        private Rectangle solveButtonArea;
        private Button solveButton;

        private bool noValidSolution;

        private readonly Rectangle[,] boardAreas;
        private int[,] matrix;

        private SudokuSolver solver;
        private int currentDigit;

        public SolveState(IState callerState)
        {
            this.callerState = callerState;
            this.digitAreas = new Rectangle[9];
            this.digitAreas[0] = new Rectangle(0, 549, 41, 46);
            this.digitAreas[1] = new Rectangle(42, 559, 50, 46);
            this.digitAreas[2] = new Rectangle(95, 565, 36, 46);
            this.digitAreas[3] = new Rectangle(134, 559, 43, 47);
            this.digitAreas[4] = new Rectangle(177, 551, 43, 45);
            this.digitAreas[5] = new Rectangle(222, 555, 46, 48);
            this.digitAreas[6] = new Rectangle(271, 546, 38, 47);
            this.digitAreas[7] = new Rectangle(312, 565, 42, 45);
            this.digitAreas[8] = new Rectangle(358, 549, 42, 46);

            this.backButtonArea = new Rectangle(26, 43, 63, 30);
            this.solveButtonArea = new Rectangle(255, 30, 96, 49);
            this.boardAreas = new Rectangle[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    this.boardAreas[i, j] = new Rectangle(i * 42 + 10, j * 42 + 110, 42, 42);
                }
            }

            this.matrix = new int[9, 9];
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Assets.SolveStateTexture, Vector2.Zero);
            this.backButton.Draw(gameTime, spriteBatch);
            this.solveButton.Draw(gameTime, spriteBatch);
            for (int i = 0; i < 9; i++)
            {
                this.digitButtons[i].Draw(gameTime, spriteBatch);
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (this.matrix[i, j] != 0)
                    {
                        spriteBatch.Draw(Assets.Digits[this.matrix[i, j] - 1], new Vector2(i * 42 + 12, j * 42 + 112));
                    }
                }
            }            

            if (this.noValidSolution) spriteBatch.Draw(Assets.NoSolutionMessage, new Vector2(117, 75));
            spriteBatch.End();
        }

        public void Update(GameTime gameTime)
        {
            this.backButton.IsHighlighted = this.backButtonArea.Contains(Mouse.GetState().Position);
            this.solveButton.IsHighlighted = this.solveButtonArea.Contains(Mouse.GetState().Position);
            for (int i = 0; i < 9; i++)
            {
                if (this.digitAreas[i].Contains(Mouse.GetState().Position)
                    && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        this.digitButtons[j].IsHighlighted = false;
                    }

                    this.currentDigit = i + 1;
                    this.digitButtons[i].IsHighlighted = true;
                }
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (this.boardAreas[i, j].Contains(Mouse.GetState().Position)
                        && Mouse.GetState().LeftButton == ButtonState.Pressed && this.currentDigit != 0)
                    {
                        this.matrix[i, j] = this.currentDigit;
                    }
                }
            }

            if (this.backButtonArea.Contains(Mouse.GetState().Position)
                && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                StateManager.CurrentState = this.callerState;
            }

            if (this.solveButtonArea.Contains(Mouse.GetState().Position)
                && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                this.solver = new SudokuSolver(this.matrix);
                try
                {
                    this.matrix = this.solver.Solve();
                    this.noValidSolution = false;
                }
                catch (InvalidSudokuCombinationException)
                {
                    this.noValidSolution = true;
                }
            }
        }

        public void LoadButtons()
        {
            this.backButton = new Button(Assets.BackButton, Assets.BackButtonHighlighted, new Vector2(20, 40));
            this.solveButton = new Button(Assets.SolveButton, Assets.SolveButtonHighlighted, new Vector2(255, 30));
            this.digitButtons = new Button[9];
            this.digitButtons[0] = new Button(Assets.DigitButtons[0], Assets.DigitButtonsHighlighted[0], new Vector2(0, 549));
            this.digitButtons[1] = new Button(Assets.DigitButtons[1], Assets.DigitButtonsHighlighted[1], new Vector2(42, 559));
            this.digitButtons[2] = new Button(Assets.DigitButtons[2], Assets.DigitButtonsHighlighted[2], new Vector2(95, 565));
            this.digitButtons[3] = new Button(Assets.DigitButtons[3], Assets.DigitButtonsHighlighted[3], new Vector2(134, 559));
            this.digitButtons[4] = new Button(Assets.DigitButtons[4], Assets.DigitButtonsHighlighted[4], new Vector2(177, 551));
            this.digitButtons[5] = new Button(Assets.DigitButtons[5], Assets.DigitButtonsHighlighted[5], new Vector2(222, 555));
            this.digitButtons[6] = new Button(Assets.DigitButtons[6], Assets.DigitButtonsHighlighted[6], new Vector2(271, 546));
            this.digitButtons[7] = new Button(Assets.DigitButtons[7], Assets.DigitButtonsHighlighted[7], new Vector2(312, 565));
            this.digitButtons[8] = new Button(Assets.DigitButtons[8], Assets.DigitButtonsHighlighted[8], new Vector2(358, 549));
        }
    }
}
