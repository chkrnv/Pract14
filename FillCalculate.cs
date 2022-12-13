using LibMatrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace Pract14
{
    internal static class FillCalculate
    {
        public static void Fill(this Matrix<int> matrix, int rowCount, int columnCount, int minValue, int maxValue)
        {
            int[,] matr = new int[rowCount, columnCount];
            Random rnd = new();
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    matr[i, j] = rnd.Next(-100, 100);
                }
            }
            matrix.Add(matr);
        }

        public static int Calculate(this Matrix<int> matrix, int rowCount, int columnCount)
        {
            int res = 0;
            for (int j = 0; j < columnCount; j++)
            {
                int odd = 0;
                for (int i = 0; i < rowCount; i++)
                {
                    int item = matrix[i, j];
                    if (item % 2 != 0)
                    {
                        odd++;
                    }
                }
                if (odd == rowCount)
                {
                    res = j + 1;
                }
            }
            return res;
        }
    }
}
