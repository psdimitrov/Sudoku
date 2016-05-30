namespace Sudoku.Core
{
    using System;
    using System.Collections.Generic;

    using Sudoku.Exceptions;

    public class SudokuSolver
    {
        private const int Size = 9;
        private readonly HashSet<int>[] occupiedCols;
        private readonly HashSet<int>[] occupiedRows;
        private readonly HashSet<int>[] occupiedSqueres;

        private readonly int[,] board;

        public SudokuSolver(int[,] board)
        {
            this.board = board;
            this.occupiedCols = new HashSet<int>[Size];
            this.occupiedRows = new HashSet<int>[Size];
            this.occupiedSqueres = new HashSet<int>[Size];

            for (int i = 0; i < Size; i++)
            {
                this.occupiedCols[i] = new HashSet<int>();
                this.occupiedRows[i] = new HashSet<int>();
                this.occupiedSqueres[i] = new HashSet<int>();
            }

            this.ResultBoard = new int[Size, Size];
        }

        public int[,] ResultBoard { get; set; }

        public int[,] Solve()
        {
            this.MarkBoard();
            try
            {
                this.PutNumber(0, 1);
            }
            catch (Exception)
            {                               
            }

            return this.ResultBoard;
        }

        private void MarkBoard()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (this.board[i, j] == 0)
                    {
                        continue;
                    }

                    if (this.CanPlaceNumberMarking(i, j, this.board[i, j]))
                    {
                        this.MarkAllAttackedPositions(i, j, this.board[i, j]);                            
                    }
                    else
                    {
                        throw new InvalidSudokuCombinationException("The combination of known numbers is invalid");
                    }
                }
            }
        }

        public void PutNumber(int row, int number)
        {
            while (true)
            {
                if (number > Size)
                {
                    this.CopySolution();
                    throw new Exception();
                }
                if (row == Size)
                {
                    row = 0;
                    number = number + 1;
                    continue;
                }
                else
                {
                    if (!this.occupiedRows[number - 1].Contains(row))
                    {
                        for (int col = 0; col < Size; col++)
                        {
                            if (this.CanPlaceNumber(row, col, number))
                            {
                                this.MarkAllAttackedPositions(row, col, number);
                                this.PutNumber(row + 1, number);
                                this.UnmarkAllAttackedPositions(row, col, number);
                            }
                        }
                    }
                    else
                    {
                        row = row + 1;
                        continue;
                    }
                }

                break;
            }
        }

        private void CopySolution()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    this.ResultBoard[i, j] = this.board[i, j];
                }
            }
        }

        private void UnmarkAllAttackedPositions(int row, int col, int number)
        {
            this.occupiedCols[number - 1].Remove(col);
            this.occupiedRows[number - 1].Remove(row);
            this.occupiedSqueres[number - 1].Remove(row / 3 * 3 + col / 3);

            this.board[row, col] = 0;
        }

        private void MarkAllAttackedPositions(int row, int col, int number)
        {
            this.occupiedCols[number - 1].Add(col);
            this.occupiedRows[number - 1].Add(row);
            this.occupiedSqueres[number - 1].Add(row / 3 * 3 + col / 3);

            this.board[row, col] = number;
        }

        private bool CanPlaceNumber(int row, int col, int number)
        {
            var positionOccupied = this.occupiedCols[number - 1].Contains(col) 
                || this.board[row, col] != 0 
                || this.occupiedSqueres[number - 1].Contains(row / 3 * 3 + col / 3) 
                || this.occupiedRows[number - 1].Contains(row);

            return !positionOccupied;
        }

        private bool CanPlaceNumberMarking(int row, int col, int number)
        {
            var positionOccupied = this.occupiedCols[number - 1].Contains(col) 
                || this.occupiedSqueres[number - 1].Contains(row / 3 * 3 + col / 3) 
                || this.occupiedRows[number - 1].Contains(row);

            return !positionOccupied;
        }
    }  
}
