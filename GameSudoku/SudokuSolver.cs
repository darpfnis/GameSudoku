using GameSudoku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuSolver
{
    class SudokuSolverLogic
    {
        private int[,] puzzle = new int[9, 9];  // Матриця для збереження судоку
        private Button[,] buttons = new Button[9, 9];  // Матриця кнопок для відображення судоку
        private Stack<(int, int, int)> steps = new Stack<(int, int, int)>();  // Стек для збереження кроків
        private List<(int, int)> emptyCells = new List<(int, int)>();  // Список порожніх комірок
        private Dictionary<(int, int), List<int>> candidates = new Dictionary<(int, int), List<int>>();  // Словник кандидатів для кожної комірки
        private int[,] initialPuzzle = new int[9, 9];  // Початкове розміщення судоку
        private int currentIndex = 0;  // Поточний індекс
        private SudokuInitialize initialize;
        public int[,] solvedPuzzle;
        private List<(int, int)> hintCells = new List<(int, int)>();  // Список комірок для підказок

        // Конструктор класу
        public SudokuSolverLogic(int[,] puzzle, Button[,] buttons, Stack<(int, int, int)> steps, List<(int, int)> emptyCells, Dictionary<(int, int), List<int>> candidates, int[,] initialPuzzle, int currentIndex)
        {
            this.puzzle = puzzle;
            this.buttons = buttons;
            this.steps = steps;
            this.emptyCells = emptyCells;
            this.candidates = candidates;
            this.initialPuzzle = initialPuzzle;
            this.currentIndex = currentIndex;
            initialize = new SudokuInitialize();
        }

        // Завантаження початкового стану судоку
        public void LoadPuzzle()
        {
            int[,] initial = new int[9, 9]
            {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            };

            Array.Copy(initial, initialPuzzle, initial.Length);  // Копіювання початкового стану
            Array.Copy(initial, puzzle, initial.Length);  // Копіювання у поточний стан
            emptyCells.Clear();  // Очищення списку порожніх комірок
            steps.Clear();  // Очищення стеку кроків
            candidates.Clear();  // Очищення кандидатів
            currentIndex = 0;  // Скидання поточного індексу

            // Заповнення порожніх комірок та кандидатів
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (puzzle[row, col] == 0)
                    {
                        emptyCells.Add((row, col));
                        candidates[(row, col)] = GetPossibleNumbers(row, col);
                    }
                }
            }
            DisplayPuzzle();  // Відображення судоку
        }

        // Обробка натиснення кнопок
        public void ClickButtons(object sender)
        {
            Button pressedButton = sender as Button;
            string buttonText = pressedButton.Text;
            int row = -1, col = -1;

            // Пошук кнопки, яку натиснули
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (buttons[i, j] == pressedButton)
                    {
                        row = i;
                        col = j;
                        break;
                    }
                }
                if (row != -1 && col != -1)
                    break;
            }

            // Оновлення значення у судоку
            if (row != -1 && col != -1)
            {
                if (string.IsNullOrEmpty(buttonText))
                {
                    puzzle[row, col] = 1;
                }
                else
                {
                    int num = int.Parse(buttonText) + 1;
                    if (num == 10)
                        num = 1;
                    puzzle[row, col] = num;
                }
                DisplayPuzzle();  // Відображення оновленого судоку
            }
        }

        // Автоматичне розв'язання судоку
        public void SolveSudokuAutomatically()
        {
            // Очищення некоректних значень
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (!IsValid(row, col, puzzle[row, col]))
                    {
                        puzzle[row, col] = 0;
                        buttons[row, col].Text = "";
                    }
                }
            }

            // Копіюємо значення з розв'язаної сітки в сітку гри
            Array.Copy(solvedPuzzle, puzzle, solvedPuzzle.Length);

            // Оновлення відображення сітки гри
            DisplayPuzzle();

            // Повідомлення користувачу про успішне вирішення гри
            MessageBox.Show("Гра вирішена!");
        }

        // Отримання можливих чисел для комірки
        public List<int> GetPossibleNumbers(int row, int col)
        {
            List<int> possibleNumbers = new List<int>();

            for (int num = 1; num <= 9; num++)
            {
                if (IsValid(row, col, num))
                {
                    possibleNumbers.Add(num);
                }
            }

            return possibleNumbers;
        }

        // Перевірка, чи є число допустимим у комірці
        public bool IsValid(int row, int col, int num)
        {
            for (int i = 0; i < 9; i++)
            {
                if (puzzle[row, i] == num || puzzle[i, col] == num || puzzle[row / 3 * 3 + i / 3, col / 3 * 3 + i % 3] == num)
                {
                    return false;
                }
            }
            return true;
        }

        // Відображення судоку
        public void DisplayPuzzle()
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    buttons[row, col].Text = puzzle[row, col] == 0 ? "" : puzzle[row, col].ToString();
                }
            }
        }

        // Розв'язання наступного кроку
        public void SolveNextStep()
        {
            if (!SolveCellInSquare() && !SolveCellInRow() && !SolveCellInColumn())
            {
                MakePrediction();
            }
            DisplayPuzzle();
        }

        // Скасування останньої дії
        public void UndoAction()
        {
            if (steps.Count > 0)
            {
                var (row, col, num) = steps.Pop();
                puzzle[row, col] = 0;
                emptyCells.Insert(0, (row, col));
                candidates[(row, col)].Add(num);
                currentIndex--;
            }
        }
        // Використання "передбачення" у випадку занадто великої кількості ймовірних ходів
        private void MakePrediction()
        {
            if (emptyCells.Count == 0)
            {
                return;
            }

            Random rand = new Random();
            var (row, col) = emptyCells[rand.Next(emptyCells.Count)];
            var possibleNumbers = GetPossibleNumbers(row, col);

            if (possibleNumbers.Count > 0)
            {
                int num = possibleNumbers[rand.Next(possibleNumbers.Count)];
                puzzle[row, col] = num;
                steps.Push((row, col, num));
                emptyCells.Remove((row, col));
                buttons[row, col].ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                buttons[row, col].ForeColor = System.Drawing.Color.Black;
                UndoAction();
                MakePrediction();
            }
        }
        // Метод розв'язку судоку "один у квадраті"
        private bool SolveCellInSquare()
        {
            for (int num = 1; num <= 9; num++)
            {
                for (int row = 0; row < 9; row += 3)
                {
                    for (int col = 0; col < 9; col += 3)
                    {
                        int count = 0;
                        int r = -1, c = -1;
                        for (int i = row; i < row + 3; i++)
                        {
                            for (int j = col; j < col + 3; j++)
                            {
                                if (puzzle[i, j] == 0 && IsValid(i, j, num))
                                {
                                    count++;
                                    r = i;
                                    c = j;
                                }
                            }
                        }
                        if (count == 1)
                        {
                            puzzle[r, c] = num;
                            steps.Push((r, c, num));
                            emptyCells.Remove((r, c));
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        // Метод розв'язку судоку "один у рядку"
        private bool SolveCellInRow()
        {
            for (int row = 0; row < 9; row++)
            {
                for (int num = 1; num <= 9; num++)
                {
                    int count = 0;
                    int pos = -1;
                    for (int col = 0; col < 9; col++)
                    {
                        if (puzzle[row, col] == 0 && IsValid(row, col, num))
                        {
                            count++;
                            pos = col;
                        }
                    }
                    if (count == 1)
                    {
                        puzzle[row, pos] = num;
                        steps.Push((row, pos, num));
                        emptyCells.Remove((row, pos));
                        return true;
                    }
                }
            }
            return false;
        }
        // Метод розв'язку судоку "один у стовпчику"
        private bool SolveCellInColumn()
        {
            for (int col = 0; col < 9; col++)
            {
                for (int num = 1; num <= 9; num++)
                {
                    int count = 0;
                    int pos = -1;
                    for (int row = 0; row < 9; row++)
                    {
                        if (puzzle[row, col] == 0 && IsValid(row, col, num))
                        {
                            count++;
                            pos = row;
                        }
                    }
                    if (count == 1)
                    {
                        puzzle[pos, col] = num;
                        steps.Push((pos, col, num));
                        emptyCells.Remove((pos, col));
                        return true;
                    }
                }
            }
            return false;
        }
        // Скидання головоломки до початкового стану
    public void ResetPuzzle()
        {
            Array.Copy(initialPuzzle, puzzle, initialPuzzle.Length);
            emptyCells.Clear();
            steps.Clear();
            candidates.Clear();
            currentIndex = 0;

            for (int row = 0; 9 > row; row++)
            {
                for (int col = 0; 9 > col; col++)
                {
                    if (puzzle[row, col] == 0)
                    {
                        emptyCells.Add((row, col));
                        candidates[(row, col)] = GetPossibleNumbers(row, col);
                    }
                }
            }
            foreach (var cell in hintCells)
            {
                buttons[cell.Item1, cell.Item2].Enabled = true;
                buttons[cell.Item1, cell.Item2].ForeColor = System.Drawing.Color.Black;
            }
            hintCells.Clear();
        }
        // Створення випадкової сітки судоку
        public void GenerateRandomPuzzle(int cluesToRemove)
        {
            puzzle = new int[9, 9];

            FillDiagonalBlocks();

            SolveSudoku();

            solvedPuzzle = new int[9, 9];
            Array.Copy(puzzle, solvedPuzzle, puzzle.Length);

            Random rand = new Random();
            for (int i = 0; i < 5; i++)  
            {
                ShuffleMap(rand.Next(5));
            }

            while (cluesToRemove > 0)
            {
                int row = rand.Next(9);
                int col = rand.Next(9);
                if (puzzle[row, col] != 0)
                {
                    puzzle[row, col] = 0;
                    cluesToRemove--;
                }
            }

            if (!IsSolvable())
            {
                Array.Copy(solvedPuzzle, puzzle, puzzle.Length);
                GenerateRandomPuzzle(cluesToRemove);
            }

            Array.Copy(puzzle, initialPuzzle, puzzle.Length);
            emptyCells.Clear();
            steps.Clear();
            candidates.Clear();
            currentIndex = 0;

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (puzzle[row, col] == 0)
                    {
                        emptyCells.Add((row, col));
                        candidates[(row, col)] = GetPossibleNumbers(row, col);
                        buttons[row, col].ForeColor = System.Drawing.Color.Black;
                        buttons[row, col].Enabled = true;
                    }
                    else
                    {
                        buttons[row, col].Text = puzzle[row, col].ToString();
                        buttons[row, col].Enabled = false;
                    }
                }
            }
            DisplayPuzzle();
        }

        // Перевірка чи створена сітка може існувати по правилам гри(зберігає поточний стан, розв'язує його)
        public bool IsSolvable()
        {
            int[,] puzzleCopy = new int[9, 9];
            Array.Copy(puzzle, puzzleCopy, puzzle.Length);
            return SolveSudoku(puzzleCopy);
        }
        // Метод розв'язання судоку для перевірки існування сітки(копія масиву)
        public bool SolveSudoku(int[,] board)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (board[row, col] == 0)
                    {
                        for (int num = 1; num <= 9; num++)
                        {
                            if (IsValid(row, col, num, board))
                            {
                                board[row, col] = num;

                                if (SolveSudoku(board))
                                {
                                    return true;
                                }

                                board[row, col] = 0;
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }
        // Переввірка числа, що вставляються в сітку судоку
        public bool IsValid(int row, int col, int num, int[,] board)
        {
            for (int i = 0; i < 9; i++)
            {
                if (board[row, i] == num || board[i, col] == num)
                {
                    return false;
                }
            }

            int startRow = row / 3 * 3;
            int startCol = col / 3 * 3;

            for (int i = startRow; i < startRow + 3; i++)
            {
                for (int j = startCol; j < startCol + 3; j++)
                {
                    if (board[i, j] == num)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        // Перемішування сітки гри
        public void ShuffleMap(int i)
        {
            switch (i)
            {
                case 0:
                    initialize.MatrixTransposition();
                    break;
                case 1:
                    initialize.SwapRowsInBlock();
                    break;
                case 2:
                    initialize.SwapColumnsInBlock();
                    break;
                case 3:
                    initialize.SwapBlocksInRow();
                    break;
                case 4:
                    initialize.SwapBlocksInColumn();
                    break;
                default:
                    initialize.MatrixTransposition();
                    break;
            }
        }
        // Метод розв'язання гри(оригінальний масив)
        public bool SolveSudoku()
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (puzzle[row, col] == 0)
                    {
                        for (int num = 1; num <= 9; num++)
                        {
                            if (IsValid(row, col, num))
                            {
                                puzzle[row, col] = num;

                                if (SolveSudoku())
                                {
                                    return true;
                                }

                                puzzle[row, col] = 0;
                            }
                        }

                        return false;
                    }
                }
            }
            return true;
        }
        // Надання підказки користувачу
        public void GiveHint()
        {
            int minPossibleNumbers = 10;
            int hintRow = -1;
            int hintCol = -1;
            List<int> hintNumbers = null;

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (puzzle[row, col] == 0)
                    {
                        List<int> possibleNumbers = GetPossibleNumbers(row, col);
                        if (possibleNumbers.Count < minPossibleNumbers)
                        {
                            minPossibleNumbers = possibleNumbers.Count;
                            hintRow = row;
                            hintCol = col;
                            hintNumbers = possibleNumbers;
                        }
                    }
                }
            }

            if (hintRow != -1 && hintCol != -1)
            {
                int hintNumber = solvedPuzzle[hintRow, hintCol];
                puzzle[hintRow, hintCol] = hintNumber;
                buttons[hintRow, hintCol].Text = hintNumber.ToString();
                buttons[hintRow, hintCol].ForeColor = System.Drawing.Color.Blue;
                buttons[hintRow, hintCol].Enabled = false;
                hintCells.Add((hintRow, hintCol));
            }
            else
            {
                MessageBox.Show("Не вдалося знайти підказку.");
            }
        }
        // Заповнення діагональних блоків
        public void FillDiagonalBlocks()
        {
            for (int i = 0; i < 9; i += 3)
            {
                FillBlock(i, i);
            }
        }
        // Заповнення блоку
        public void FillBlock(int row, int col)
        {
            Random rand = new Random();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int num;
                    do
                    {
                        num = rand.Next(1, 10);
                    } while (!IsValidInBlock(row, col, num));
                    puzzle[row + i, col + j] = num;
                }
            }
        }
        //Перевірка заповнення блоку
        public bool IsValidInBlock(int startRow, int startCol, int num)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (puzzle[startRow + row, startCol + col] == num)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
