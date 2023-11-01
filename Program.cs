using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice1;
            do
            {
                Console.WriteLine("Введiть кiлькiсть дробiв: (1 або 2) aбо цифру 3 для виконання методiв CalcExpr1 та CalcExpr2\nВведiть 0, якщо бажаєте закрити консоль");
                choice1 = int.Parse(Console.ReadLine());
                switch (choice1)
                {
                    case 1:
                        Console.WriteLine("Введiть чисельник i знаменник дробу через enter");
                        long nom = long.Parse(Console.ReadLine());
                        long denom = long.Parse(Console.ReadLine());
                        if (denom != 0)
                        {
                            MyFrac frac = new MyFrac(nom, denom);
                            Console.WriteLine("Введiть яку задачу виконати: \n1 - Видiлити цiлу частину\n2 - Сформуватиме дiйсне значення дробу");
                            int choice2 = int.Parse(Console.ReadLine());
                            switch (choice2)
                            {
                                case 1:
                                    Console.WriteLine(MyFrac.ToStringWithIntegerPart(frac));
                                    break;
                                case 2:
                                    Console.WriteLine("Дiйсне значення дробу:\n{0}", MyFrac.DoubleValue(frac));
                                    break;
                                default:
                                    Console.WriteLine("Введiть число з перелiчених");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Знаменник не може дорівнювати 0, спробуйте ще раз");
                        }
                        break;
                    case 2:
                        Console.WriteLine($"Введiть чисельник i знаменник 1-ого дробу через enter");
                        long nom1 = long.Parse(Console.ReadLine());
                        long denom1 = long.Parse(Console.ReadLine());
                        Console.WriteLine($"Введiть чисельник i знаменник 2-ого дробу через enter");
                        long nom2 = long.Parse(Console.ReadLine());
                        long denom2 = long.Parse(Console.ReadLine());
                        if (denom1 != 0 && denom2 != 0)
                        {
                            MyFrac f1 = new MyFrac(nom1, denom1);
                            MyFrac f2 = new MyFrac(nom2, denom2);
                            Console.WriteLine("Введiть яку задачу виконати: \n1 - Сума дробів\n2 - Рiзниця дробiв\n3 - Добуток дробiв\n4 - Частка");
                            int choice3 = int.Parse(Console.ReadLine());
                            switch (choice3)
                            {
                                case 1:
                                    Console.WriteLine("Сума дробiв:");
                                    Console.WriteLine(MyFrac.Plus(f1, f2));
                                    break;
                                case 2:
                                    Console.WriteLine("Різниця дробiв:");
                                    Console.WriteLine(MyFrac.Minus(f1, f2));
                                    break;
                                case 3:
                                    Console.WriteLine("Добуток дробiв:");
                                    Console.WriteLine(MyFrac.Multiply(f1, f2));
                                    break;
                                case 4:
                                    Console.WriteLine("Частка:");
                                    Console.WriteLine(MyFrac.Divide(f1, f2));
                                    break;
                                default:
                                    Console.WriteLine("Введiть число з перелічених");
                                    break;

                            }
                        }
                        else
                        {
                            Console.WriteLine("Знаменник в якомусь дробi дорівнює 0, отже дрiб не може iснувати, спробуйте ще раз");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Оберiть, який метод виконати\n1 - CalcExpr1\n2 - CalcExpr2");
                        int choice4 = int.Parse(Console.ReadLine());
                        switch (choice4)
                        {
                            case 1:
                                Console.WriteLine("Введiть кiлькiсть циклiв:");
                                int n = int.Parse(Console.ReadLine());
                                Console.WriteLine(MyFrac.CalcExpr1(n));
                                break;
                            case 2:
                                Console.WriteLine("Введiть кiлькiсть циклiв:");
                                int n1 = int.Parse(Console.ReadLine());
                                Console.WriteLine(MyFrac.CalcExpr2(n1));
                                break;
                            default:
                                Console.WriteLine("Введiть число з перелiчених");
                                break;

                        }
                        break;
                    default:
                        Console.WriteLine("Введiть число з перелiчених");
                        break;
                }
            } while (choice1 != 0);
        }
    }
}
