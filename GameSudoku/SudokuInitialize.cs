using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSudoku
{
    internal class SudokuInitialize
    {
        private int[,] puzzle = new int[9, 9];

        public SudokuInitialize() { 
        }
        public void MatrixTransposition()
        {
            int[,] tMap = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    tMap[i, j] = puzzle[j, i];
                }
            }
            puzzle = tMap;
        }

        public void SwapRowsInBlock()
        {
            Random r = new Random();
            var block = r.Next(0, 3);
            var row1 = r.Next(0, 3);
            var line1 = block * 3 + row1;
            var row2 = r.Next(0, 3);
            while (row1 == row2)
                row2 = r.Next(0, 3);
            var line2 = block * 3 + row2;
            for (int i = 0; i < 9; i++)
            {
                var temp = puzzle[line1, i];
                puzzle[line1, i] = puzzle[line2, i];
                puzzle[line2, i] = temp;
            }
        }
        public void SwapColumnsInBlock()
        {
            Random r = new Random();
            var block = r.Next(0, 3);
            var col1 = r.Next(0, 3);
            var line1 = block * 3 + col1;
            var col2 = r.Next(0, 3);
            while (col1 == col2)
                col2 = r.Next(0, 3);
            var line2 = block * 3 + col2;
            for (int i = 0; i < 9; i++)
            {
                var temp = puzzle[i, line1];
                puzzle[i, line1] = puzzle[i, line2];
                puzzle[i, line2] = temp;
            }
        }

        public void SwapBlocksInRow()
        {
            Random r = new Random();
            var block1 = r.Next(0, 3);
            var block2 = r.Next(0, 3);
            while (block1 == block2)
                block2 = r.Next(0, 3);
            block1 *= 3;
            block2 *= 3;
            for (int i = 0; i < 9; i++)
            {
                var temp = puzzle[block1, i];
                puzzle[block1, i] = puzzle[block2, i];
                puzzle[block2, i] = temp;
            }
        }
        public void SwapBlocksInColumn()
        {
            Random r = new Random();
            var block1 = r.Next(0, 3);
            var block2 = r.Next(0, 3);
            while (block1 == block2)
                block2 = r.Next(0, 3);
            block1 *= 3;
            block2 *= 3;
            for (int i = 0; i < 9; i++)
            {
                var temp = puzzle[i, block1];
                puzzle[i, block1] = puzzle[i, block2];
                puzzle[i, block2] = temp;
            }
        }
    }
}
