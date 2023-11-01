using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_task1
{
    partial class MyMatrix
    {
        protected double[,] matrix;

        public MyMatrix(int rows, int cols)
        {
            matrix = new double[rows, cols];
        }
        ///////////////////конструктори/////////////////////
        public MyMatrix(MyMatrix copyMyMatrix)
        {
            int rows = copyMyMatrix.Height;
            int cols = copyMyMatrix.Width;
            matrix = new double[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = copyMyMatrix[i, j];
                }
            }
        }
        public MyMatrix(double[,] other)
        {
            int rows = other.GetLength(0);
            int cols = other.GetLength(1);
            matrix = new double[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = other[i, j];
                }
            }
        }
        public MyMatrix(double[][] other)
        {
            IsArrayJaggedEmpty(other);
            int rows = other.Length;
            int cols = other[0].Length;
            matrix = new double[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                if (other[i].Length != cols)
                    throw new ArgumentException("Введений не прямокутний масив");
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = other[i][j];
                }
            }
        }
        public MyMatrix(string[] strings)
        {
            int rows = strings.Length;
            int cols = strings[0].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;

            matrix = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] values = strings[i].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                if (values.Length != cols)
                    throw new ArgumentException("У рядках введена не однакова кількість елементів");

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = double.Parse(values[j]);
                }
            }
        }
        public MyMatrix(string elems)
        {
            string[] rows = elems.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            int numRows = rows.Length;
            int numCols = rows[0].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;

            matrix = new double[numRows, numCols];

            for (int i = 0; i < numRows; i++)
            {
                string[] nums = rows[i].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                if (nums.Length != numCols)
                {
                    throw new ArgumentException("Введений рядок неможливо переформувати у прямокутну матрицю");
                }
                for (int j = 0; j < numCols; j++)
                {
                    matrix[i, j] = double.Parse(nums[j]);
                }
            }
        }

        /////////////////////////////Властивості////////////////////////////////

        public int Height
        {
            get { return matrix.GetLength(0); }
        }
        public int Width
        {
            get { return matrix.GetLength(1); }
        }

        ///////////////////////////Java-style getter-и//////////////////////////////

        public int getHeight()
        {
            return Height;
        }

        public int getWidth()
        {
            return Width;
        }

        ////////////////////////////////Індексатори/////////////////////////////////
        public double this[int row, int col]
        {
            get { return matrix[row, col]; }
            set { matrix[row, col] = value; }
        }

        /////////// Java-style getter та setter для окремого елемента//////////
        public double GetElement(int row, int col)
        {
            return matrix[row, col];
        }

        public void SetElement(int row, int col, double value)
        {
            matrix[row, col] = value;
        }

        //////////////////// перевiркa ///////////////////////////
        private void IsArrayJaggedEmpty(double[][] jaggedArray)
        {
            if (jaggedArray == null || jaggedArray.Length == 0 || jaggedArray[0] == null)
            {
                throw new ArgumentException("Зубчастий масив дорiвнює нул або пустий");
            }
        }

        public override string ToString()
        {
            int rows = Height;
            int cols = Width;
            string result = "";

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result += matrix[i, j].ToString() + "\t";
                }
                result += "\n";
            }
            return result;
        }
    }
}