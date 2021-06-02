using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuKata
{
    public static class Sudoku
    {
        private const int Size = 9;

        public static bool ValidSolution(int[][] sudoku)
        {
            int length = sudoku?.Length ?? throw new ArgumentNullException(nameof(sudoku));
            if (length != Size || sudoku.Any(x => x?.Length != Size))
            {
                return false;
            }

            if (!ValidateSudoku(sudoku))
            {
                return false;
            }

            const int offset = 3;
            for (int i = 0; i < Size; i += offset)
            {
                for (int j = 0; j < Size; j += offset)
                {
                    if (!ValidateSubGrid(sudoku, offset, i, j))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static bool ValidateSudoku(int[][] sudoku)
        {
            for (int i = 0; i < Size; i++)
            {
                var validator = new bool[Size];
                for (int j = 0; j < Size; j++)
                {
                    int valueIndex = sudoku[i][j] - 1;
                    if (!validator.IsValid(valueIndex))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static bool ValidateSubGrid(int[][] sudoku, int size, int iOffset, int jOffset)
        {
            var validator = new bool[Size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int valueIndex = sudoku[i + iOffset][j + jOffset] - 1;
                    if (!validator.IsValid(valueIndex))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static bool IsValid(this IList<bool> validator, int index)
        {
            if (index < 0 || index >= Size)
            {
                return false;
            }

            bool isEmpty = !validator[index];
            validator[index] = true;
            return isEmpty;
        }
    }
}