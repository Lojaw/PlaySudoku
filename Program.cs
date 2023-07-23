using System;
using System.Collections.Generic;

namespace PlaySudoku

{
    class Program
    {

        static void Main()
        {
            while (true)
            {
                PlayGame();
                Console.WriteLine("Möchten Sie erneut spielen? (j/n)");
                var input = Console.ReadLine();
                if (input.ToLower() != "j")
                {
                    break;
                }
            }
        }

        public static void PlayGame()
        {
            SudokuSolver solver = new SudokuSolver();
            SudokuGenerator generator = new SudokuGenerator(solver);

            Difficulty difficulty;
            while (true)
            {
                Console.WriteLine("Bitte wählen Sie eine Schwierigkeitsstufe: 1 - Einfach, 2 - Mittel, 3 - Schwer");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    difficulty = Difficulty.Easy;
                    break;
                }
                else if (input == "2")
                {
                    difficulty = Difficulty.Medium;
                    break;
                }
                else if (input == "3")
                {
                    difficulty = Difficulty.Hard;
                    break;
                }
                else
                {
                    Console.WriteLine("Ungültige Eingabe. Bitte versuchen Sie es erneut.");
                }
            }

            SudokuBoard board = generator.GeneratePuzzle(difficulty);
            SudokuBoard solutionBoard = new SudokuBoard(board); // Erstellung einer Kopie des Bretts für die Lösung
            SudokuBoard initialBoard = new SudokuBoard(board);

            int cursorRow = 0;
            int cursorCol = 0;

            while (true)
            {
                Console.Clear();
                board.PrintBoard(cursorRow, cursorCol); // Das board mit der aktuellen Cursorposition ausgeben

                Console.WriteLine("");
                //string text =
                //"Verwenden Sie die Pfeiltasten, um sich zu bewegen, die Zifferntasten, um eine Zelle auszufüllen " +
                //"und die Eingabetaste, um die Lösung zu überprüfen. Wenn Sie Hilfe brauchen, dann drücken Sie 'L', um " +
                //"die Lösung anzusehen oder 'R', um ein neues Sudoku zu lösen.";

                Console.Write("Verwenden Sie die ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Pfeiltasten");
                Console.ResetColor();

                Console.WriteLine(", um sich zu bewegen, die ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Zifferntasten");
                Console.ResetColor();

                Console.Write(", um eine Zelle auszufüllen und die ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Eingabetaste");
                Console.ResetColor();

                Console.Write(", um die Lösung zu überprüfen.");


                Console.WriteLine("");
                Console.WriteLine("");

                Console.Write("Wenn Sie Hilfe brauchen, dann drücken Sie ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("'H'");
                Console.ResetColor();

                Console.Write(" oder");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("'L'");
                Console.ResetColor();

                Console.Write(", um die Lösung anzusehen oder ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("'R'");
                Console.ResetColor();

                Console.Write(", um ein neues Sudoku zu lösen.");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (cursorRow > 0)
                        {
                            cursorRow--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (cursorRow < 8)
                        {
                            cursorRow++;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (cursorCol > 0)
                        {
                            cursorCol--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (cursorCol < 8)
                        {
                            cursorCol++;
                        }
                        break;

                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                        if (!board.GetCell(cursorRow, cursorCol).IsFixed)
                        {
                            board.SetCell(cursorRow, cursorCol, 0, false);
                        }
                        break;

                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        if (!board.GetCell(cursorRow, cursorCol).IsFixed)
                        {
                            board.SetCell(cursorRow, cursorCol, 1, false);
                        }
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        if (!board.GetCell(cursorRow, cursorCol).IsFixed)
                        {
                            board.SetCell(cursorRow, cursorCol, 2, false);
                        }
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        if (!board.GetCell(cursorRow, cursorCol).IsFixed)
                        {
                            board.SetCell(cursorRow, cursorCol, 3, false);
                        }
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        if (!board.GetCell(cursorRow, cursorCol).IsFixed)
                        {
                            board.SetCell(cursorRow, cursorCol, 4, false);
                        }
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        if (!board.GetCell(cursorRow, cursorCol).IsFixed)
                        {
                            board.SetCell(cursorRow, cursorCol, 5, false);
                        }
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        if (!board.GetCell(cursorRow, cursorCol).IsFixed)
                        {
                            board.SetCell(cursorRow, cursorCol, 6, false);
                        }
                        break;
                    case ConsoleKey.D7:
                    case ConsoleKey.NumPad7:
                        if (!board.GetCell(cursorRow, cursorCol).IsFixed)
                        {
                            board.SetCell(cursorRow, cursorCol, 7, false);
                        }
                        break;
                    case ConsoleKey.D8:
                    case ConsoleKey.NumPad8:
                        if (!board.GetCell(cursorRow, cursorCol).IsFixed)
                        {
                            board.SetCell(cursorRow, cursorCol, 8, false);
                        }
                        break;
                    case ConsoleKey.D9:
                    case ConsoleKey.NumPad9:
                        if (!board.GetCell(cursorRow, cursorCol).IsFixed)
                        {
                            board.SetCell(cursorRow, cursorCol, 9, false);
                        }
                        break;

                    case ConsoleKey.L:
                        solver.Solve(solutionBoard);
                        Console.WriteLine("\nLösung:");
                        solutionBoard.PrintBoard();
                        Console.WriteLine("\nDrücken Sie eine beliebige Taste, um fortzufahren...");
                        Console.ReadKey(true);  // wartet auf eine Benutzereingabe
                        break;

                    case ConsoleKey.R:
                        Difficulty newDifficulty = Difficulty.Easy;  // setze einen Standardwert
                        bool isCancelled = false; // Flag für Abbruch der Aktion
                        while (true)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Bitte wählen Sie eine Schwierigkeitsstufe: 1 - Einfach, 2 - Mittel, 3 - Schwer. Drücken Sie 'q', um abzubrechen.");
                            string input = Console.ReadLine();

                            if (input == "1")
                            {
                                newDifficulty = Difficulty.Easy;
                                break;
                            }
                            else if (input == "2")
                            {
                                newDifficulty = Difficulty.Medium;
                                break;
                            }
                            else if (input == "3")
                            {
                                newDifficulty = Difficulty.Hard;
                                break;
                            }
                            else if (input.ToLower() == "q") // Abbruch der Aktion
                            {
                                isCancelled = true; // setzt das Flag auf 'true', falls 'q' eingegeben wurde
                                break; // verlässt die Schleife
                            }
                            else
                            {
                                Console.WriteLine("Ungültige Eingabe. Bitte versuchen Sie es erneut.");
                            }
                        }

                        // überprüfen, ob die Aktion abgebrochen wurde, bevor der Rest des Codes ausgeführt wird
                        if (!isCancelled)
                        {
                            board = generator.GeneratePuzzle(newDifficulty);
                            solutionBoard = new SudokuBoard(board); // Erstellung eines neuen Lösungsbretts
                            cursorRow = 0;
                            cursorCol = 0;
                        }
                        break;

                    case ConsoleKey.H:  // 'H' für Hilfe
                        Console.WriteLine("");
                        Console.WriteLine($"Es gibt noch {board.CountEmptyCells()} leere Zellen.");

                        Dictionary<int, int> missingNumbers = board.CountMissingNumbers();
                        Console.WriteLine("Fehlende Zahlen:");
                        for (int number = 1; number <= 9; number++)
                        {
                            if (missingNumbers[number] > 0)
                            {
                                Console.WriteLine($"{missingNumbers[number]}x {number}");
                            }
                        }
                        Console.WriteLine("Drücken Sie eine beliebige Taste, um fortzufahren...");
                        Console.ReadKey(true);  // wartet auf eine Benutzereingabe, bevor fortgefahren wird
                        break;

                    case ConsoleKey.Enter:
                        if (board.DiffersFrom(initialBoard) && board.Equals(solutionBoard))
                        {
                            Console.Clear();
                            Console.WriteLine("Glückwunsch! Du hast das Rätsel gelöst!");
                            board.PrintBoard();
                            return;
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Das aktuelle Sudoku ist noch nicht gelöst. Drücken Sie eine beliebige Taste, um fortzufahren.");
                            Console.ReadKey(true);
                        }
                        break;
                }
            }
        }
    }
}