using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuSolver
{
    class SudokuHelper
    {
        private Button[,] buttons = new Button[9, 9];
        public SudokuHelper(Button[,] buttons)
        {
            this.buttons = buttons;
        }

        public bool IsSolutionCorrect(int[,] userSolution)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (userSolution[row, col] == 0)
                    {
                        return false;
                    }
                }
            }

            for (int i = 0; i < 9; i++)
            {
                if (!IsUniqueSet(userSolution, i, i, 0, 8) || !IsUniqueSet(userSolution, 0, 8, i, i))
                {
                    return false;
                }
            }

            for (int rowOffset = 0; rowOffset < 9; rowOffset += 3)
            {
                for (int colOffset = 0; colOffset < 9; colOffset += 3)
                {
                    if (!IsUniqueSet(userSolution, rowOffset, rowOffset + 2, colOffset, colOffset + 2))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        public bool IsUniqueSet(int[,] userSolution, int rowStart, int rowEnd, int colStart, int colEnd)
        {
            HashSet<int> set = new HashSet<int>();
            for (int i = rowStart; i <= rowEnd; i++)
            {
                for (int j = colStart; j <= colEnd; j++)
                {
                    int num = userSolution[i, j];
                    if (num != 0 && !set.Add(num))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public void DisplayInitialPuzzleAndLock()
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    buttons[row, col].Text = "";
                    buttons[row, col].Enabled = false;
                }
            }
        }

    }
}