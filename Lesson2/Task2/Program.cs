using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2 {
    class Program {
        static void Main(string[] args) {
            int Month;

            do {
                Console.Write("Укажите порядковый номер месяца (от 1 до 12): ");
                var MonthEntered = Console.ReadLine();
                try {
                    Month = Int32.Parse(MonthEntered);
                    if (Month < 1) Console.WriteLine("Порядковый номер месяца не может быть меньше 1. Ввведите заново.");
                    if (Month > 12) Console.WriteLine("Порядковый номер месяца не может быть больше 12. Введите заново.");
                }
                catch (FormatException Error) { Month = 0; Console.WriteLine("Введите число!"); }
            } while ((Month < 1) || (Month > 12));

            //  Вариант "В ЛОБ"

            /*
            switch (Month) {

                case 1: Console.WriteLine("Январь / January"); break;
                case 2: Console.WriteLine("Февраль / February"); break;
                case 3: Console.WriteLine("Март / March"); break;
                case 4: Console.WriteLine("Апрель / April"); break;
                case 5: Console.WriteLine("Май / May"); break;
                case 6: Console.WriteLine("Июнь / June"); break;
                case 7: Console.WriteLine("Июль / July"); break;
                case 8: Console.WriteLine("Август / August"); break;
                case 9: Console.WriteLine("Сентябрь / September"); break;
                case 10: Console.WriteLine("Октябрь / October"); break;
                case 11: Console.WriteLine("Ноябрь / November"); break;
                case 12: Console.WriteLine("Декабрь / December"); break;

            }
            */

            //  Вариант через "DateTime"

            DateTime date = new DateTime(2021, Month, 1);
            Console.WriteLine(date.ToString("MMMM"));

            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}