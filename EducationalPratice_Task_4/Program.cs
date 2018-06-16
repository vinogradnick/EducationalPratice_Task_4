using System;
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
        static double _func(double x) => (double)x + Math.Log(x + 0.5) - 0.5;
        static void Main(string[] args)
        {
            double x,
                a = 0, //Начальное значение отрезка
                b = 2, //Конечное значение  отрезка
                temp;//Значение шага для вычисления
            double eps = 0.001;//Положительное число погрешность которого не должна превосходить E
            Console.WriteLine("Введите Положительное число погрешность которого не должна превосходить Epsilon ");
            eps = MyLibary.Input.Double();
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
                Console.WriteLine($"[Значение функции при заданой точности {eps} ] = {x,8}");
            }
            Console.WriteLine("Для выхода введите любую клавишу");
            Console.ReadKey();
        }
    }
}
