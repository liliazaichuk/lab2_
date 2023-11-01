using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_task1
{
    partial class MyMatrix
    {
        public static MyMatrix operator +(MyMatrix first_m, MyMatrix second_m)
        {
            if (first_m.Height != second_m.Height || first_m.Width != second_m.Width)
            {
                throw new ArgumentException("Матриці мають різний розмір, додавання неможливо");
            }

            for (int i = 0; i < first_m.Height; i++)
            {
                for (int j = 0; j < first_m.Width; j++)
                {
                    first_m[i, j] += second_m[i, j];
                }
            }
            return first_m;
        }
        public static MyMatrix operator *(MyMatrix first_m, MyMatrix second_m)
        {
            if (first_m.Width != second_m.Height)
            {
                throw new ArgumentException("Кількість стовпчиків першої матриці недорівнює кількості рядків другої");
            }
            // 3 x 2 на матрицю B розміром 2 x 4 буде нова матриця C розміром 3 x 4.
            MyMatrix new_m = new MyMatrix(first_m.Height, second_m.Width);

            for (int i = 0; i < new_m.Height; i++)
            {
                for (int j = 0; j < new_m.Width; j++)
                {
                    double sum = 0;

                    for (int k = 0; k < first_m.Height; k++)
                    {
                        sum += first_m[i, k] * second_m[k, j];
                    }
                    new_m[i, j] = sum;
                }
            }

            return new_m;
        }
        private double[,] GetTransposedArray()
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            double[,] transposedArray = new double[cols, rows];

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    transposedArray[i, j] = matrix[j, i];
                }
            }

            return transposedArray;
        }

        public MyMatrix GetTransposedCopy()
        {
            double[,] transposedArray = GetTransposedArray();
            return new MyMatrix(transposedArray);
        }


        public void TransposeMe()
        {
            matrix = GetTransposedArray();
        }
    }
}
