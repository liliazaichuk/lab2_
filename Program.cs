using System;
namespace lab2_task1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            MyMatrix m1 = new MyMatrix(2, 5);
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    m1[i, j] = 1;
                }
            }
            Console.WriteLine($"m1:\n{m1}");

            MyMatrix m2 = new MyMatrix(4, 7);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    m2[i, j] = 2;
                }
            }
            Console.WriteLine($"m2:\n{m2}");

            //copy
            m1 = new MyMatrix(m2);
            Console.WriteLine($"Скопійована m2 у m1:\n{m1}");

            Console.WriteLine("Перевірка двовимірного масиву\nВведiть кiлькiсть рядків: ");
            int ryad = int.Parse(Console.ReadLine());
            Console.WriteLine("Введiть кiлькiсть стовпчиків: ");
            int stvp = int.Parse(Console.ReadLine());
            double[,] arr = new double[ryad, stvp];
            Random rand = new Random();
            for (int i = 0; i < ryad; i++)
            {
                for (int j = 0; j < stvp; j++)
                {
                    arr[i, j] = rand.Next(-100, 100);
                }
            }
            m1 = new MyMatrix(arr);
            Console.WriteLine($"Матриця з двовимірного:\n{m1}");

            Console.WriteLine("Введiть кiлькiсть рядків: ");
            int ryad1 = int.Parse(Console.ReadLine());
            double[][] jaggedArray = new double[ryad1][];
            for (int i = 0; i < ryad1; i++)
            {
                Console.Write($"Введiть кiлькiсть елементiв у {i + 1}-му рядку: ");
                int colCount = int.Parse(Console.ReadLine());
                jaggedArray[i] = new double[colCount];
                for (int j = 0; j < colCount; j++)
                {
                    Console.Write($"Введiть {j + 1}-й елемент для {i + 1}-го рядка: ");
                    jaggedArray[i][j] = double.Parse(Console.ReadLine());
                }
            }
            m1 = new MyMatrix(jaggedArray);
            Console.WriteLine($"Матриця с зубчастого:\n{m1}");



            int size = 3;
            string[] stringArray = new string[size];
            stringArray[0] = "1 2 4";
            stringArray[1] = "4 2 5";
            stringArray[2] = "1 2 3";
            m1 = new MyMatrix(stringArray);
            Console.WriteLine($"Матриця с масиву рядків:\n{m1}");

            string elems = "2    3\n 4\t\t 5\n 23 4 2 1\n 73    2    1   5";
            MyMatrix m5 = new MyMatrix(elems);
            Console.WriteLine($"Матриця з рядка:\n{m5}");


            string elems2 = "1 2\n-1 4";
            MyMatrix mnozh1 = new MyMatrix(elems2);
            string elems3 = "3 -2 1\n 4 2 0";
            MyMatrix mnozh2 = new MyMatrix(elems3);
            Console.WriteLine($"Результат множення:\n{mnozh1 * mnozh2}");
            //результат 11 2 1 \n 13 10 -1

            string elems4 = "2 3 1\n4 6 3";
            MyMatrix dod1 = new MyMatrix(elems4);
            string elems5 = "2 3 1\n 2 4 3";
            MyMatrix dod2 = new MyMatrix(elems5);
            Console.WriteLine($"Результат додавання:\n{dod1 + dod2}");

            m5.TransposeMe();
            Console.WriteLine($"Транспонована матриця:\n{m5}");
        }
    }
}
