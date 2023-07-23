namespace PlaySudoku
{
    public class SudokuSolver
    {
        public bool Solve(SudokuBoard board)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (board.GetCell(row, col).Value == 0) // eine leere Zelle finden
                    {
                        for (int num = 1; num <= 9; num++)
                        {
                            if (IsValid(board, row, col, num))
                            {
                                // diese Nummer wird für die Zelle versucht
                                board.SetCell(row, col, num, false);

                                if (Solve(board))
                                {
                                    return true; // return true bei Erfolg
                                }
                                else
                                {
                                    // falls fehlgeschlagen, Rollback und eine andere Nummer versuchen
                                    board.SetCell(row, col, 0, false);
                                }
                            }
                        }
                        return false; // wenn keine gültige Zahl in dieser Zelle platziert werden kann, wird false zurückgegeben
                    }
                }
            }
            return true; // das gesamte Board ist gefüllt
        }

        private bool IsValid(SudokuBoard board, int row, int col, int num)
        {
            // Zeile wird überprüft
            for (int i = 0; i < 9; i++)
            {
                if (board.GetCell(row, i).Value == num)
                {
                    return false;
                }
            }

            // Spalte wird überprüft
            for (int i = 0; i < 9; i++)
            {
                if (board.GetCell(i, col).Value == num)
                {
                    return false;
                }
            }

            // Box wird überprüft
            int startRow = row - row % 3, startCol = col - col % 3;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board.GetCell(i + startRow, j + startCol).Value == num)
                    {
                        return false;
                    }
                }
            }

            return true; // Kein Konflikt, return true
        }
    }
}
