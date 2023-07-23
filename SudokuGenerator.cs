using System;

namespace PlaySudoku
{
    public class SudokuGenerator
    {
        private readonly SudokuSolver solver;
        private readonly Random random;

        public SudokuGenerator(SudokuSolver solver)
        {
            this.solver = solver;
            this.random = new Random();
        }

        public SudokuBoard GeneratePuzzle(Difficulty difficulty)
        {
            SudokuBoard board = new SudokuBoard();
            solver.Solve(board);

            int numbersToRemove;
            switch (difficulty)
            {
                case Difficulty.Easy:
                    numbersToRemove = random.Next(20, 31);
                    break;
                case Difficulty.Medium:
                    numbersToRemove = random.Next(40, 51);
                    break;
                case Difficulty.Hard:
                    numbersToRemove = random.Next(60, 71);
                    break;
                default:
                    throw new ArgumentException("Ungültige Schwierigkeitsstufe.");
            }

            for (int i = 0; i < numbersToRemove; i++)
            {
                int row, col;
                do
                {
                    row = random.Next(9);
                    col = random.Next(9);
                } while (board.GetCell(row, col).Value == 0);

                board.SetCell(row, col, 0, false);
            }

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (board.GetCell(row, col).Value != 0)
                    {
                        // Wenn die Zelle einen Wert hat, dann wird sie auf 'fixed' gesetzt, damit der Benutzer sie nicht ändern kann
                        board.GetCell(row, col).IsFixed = true;
                    }
                }
            }

            return board;
        }
    }
}
