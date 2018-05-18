using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalPratice_Task_4
{
    /*
    * Задание (725а)
    * Дано действительное положительное число е.
    * Методом деления отрезка пополам найти приближенное значение корня уравнения f(x) = 0.
    * Абсолютная погрешность найденного значения не должна превосходить е.
    * (Ниже, рядом с уравнением f (*) = 0,
    * дополнительно указан отрезок, содержащий корень.)
    * х+ Ln (* + 0.5)—0.5 = 0, [0, 2];
    */
    class Program
    {
        /// <summary>
        /// Функция для которой необходимо найти значение
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        static double _func(double x)
        {
            return (double)x + Math.Log(x + 0.5) - 0.5;
        }

        static double Parse()
        {
            double result = 0;
            bool status = false;
            do
            {
                try
                {
                    result = double.Parse(Console.ReadLine());
                    status = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Вы ввели неверное число");
                }


            } while (status == false);

            return result;
        }
        static void Main(string[] args)
        {
            double x,
                a = 0,//Начальное значение отрезка
                b = 2,//Конечное значение  отрезка
                temp,//Значение шага для вычисления
                result;//Результат выполнения программы

            double eps = 0.001;//Положительное число погрешность которого не должна превосходить E
            Console.WriteLine("Введите Положительное число погрешность которого не должна превосходить E ");
            eps = Parse();
            /* Проверка значений на корни */
            if (eps > 2 || eps < 0)
                Console.WriteLine("Корней на интервале нет");
            else
            {
                /* Цикл вычисления значений функции до точности Epsilon      */
                while (Math.Abs(a - b) > eps)
                {
                    temp = (a + b) / 2.0;
                    if (_func(a) * _func(temp) <= 0)
                        b = temp;
                    else
                        a = temp;
                }
                x = (double)(a + b) / 2.0;
                Console.WriteLine($"{x}");
            }
            Console.ReadKey();
        }
    }
}
