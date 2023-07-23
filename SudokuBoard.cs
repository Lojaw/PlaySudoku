using System;
using System.Collections.Generic;

namespace PlaySudoku
{
    public class SudokuBoard
    {
        private readonly SudokuCell[,] board;

        public SudokuBoard()
        {
            board = new SudokuCell[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    board[i, j] = new SudokuCell(0, false);
                }
            }
        }

        public SudokuBoard(SudokuBoard other)
        {
            board = new SudokuCell[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    SudokuCell cell = other.GetCell(i, j);
                    board[i, j] = new SudokuCell(cell.Value, cell.IsFixed);
                }
            }
        }


        public SudokuCell GetCell(int row, int col)
        {
            return board[row, col];
        }

        public void SetCell(int row, int col, int value, bool isFixed)
        {
            board[row, col].Value = value;
            board[row, col].IsFixed = isFixed;
        }

        public void PrintBoard(int cursorRow = -1, int cursorCol = -1)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (row == cursorRow && col == cursorCol)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else if (GetCell(row, col).IsFixed)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan; // Farbe für nicht veränderbare Zellen
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue; // Farbe für veränderbare Zellen
                    }

                    SudokuCell cell = GetCell(row, col);
                    Console.Write(cell.Value != 0 ? cell.Value.ToString() : " ");

                    Console.ResetColor();

                    if (col < 8)
                    {
                        Console.Write(" | ");
                    }
                }
                Console.WriteLine();

                if (row < 8)
                {
                    Console.WriteLine("---------------------------------");
                }
            }
        }

        public bool DiffersFrom(SudokuBoard otherBoard)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (this.GetCell(row, col).Value != otherBoard.GetCell(row, col).Value)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is SudokuBoard))
            {
                return false;
            }

            SudokuBoard otherBoard = (SudokuBoard)obj;

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (this.GetCell(row, col).Value != otherBoard.GetCell(row, col).Value)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public int CountEmptyCells()
        {
            int count = 0;
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (this.GetCell(row, col).Value == 0)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public Dictionary<int, int> CountMissingNumbers()
        {
            // Erstelle ein Dictionary, um zu speichern, wie oft jede Zahl von 1 bis 9 auf dem Brett erscheint.
            Dictionary<int, int> counts = new Dictionary<int, int>()
            {
                { 1, 0 },
                { 2, 0 },
                { 3, 0 },
                { 4, 0 },
                { 5, 0 },
                { 6, 0 },
                { 7, 0 },
                { 8, 0 },
                { 9, 0 },
            };

            // Durchlaufe jede Zelle auf dem Brett und erhöhe den Zähler für die jeweilige Zahl.
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    int value = this.GetCell(row, col).Value;
                    if (value != 0)
                    {
                        counts[value]++;
                    }
                }
            }

            // Durchlaufe das Dictionary und ändere jeden Zähler in die Anzahl der fehlenden Zahlen.
            for (int number = 1; number <= 9; number++)
            {
                counts[number] = 9 - counts[number];  // Jede Zahl sollte 9 Mal in einem vollständig gelösten Sudoku erscheinen.
            }

            return counts;
        }
    }
}
