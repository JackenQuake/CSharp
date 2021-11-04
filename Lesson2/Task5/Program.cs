using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5 {
    class Program {
        enum Season {
            Spring,
            Summer,
            Autumn,
            Winter,
            NoSeason // Что бы обозначить несуществующий месяц
        };
        static void Main(string[] args) {
            int Month;

            // Ввводим месяц
            do {
                Console.Write("Укажите порядковый номер месяца (от 1 до 12): ");
                var MonthEntered = Console.ReadLine();
                try {
                    Month = Int32.Parse(MonthEntered);
                    if (Month < 1) Console.WriteLine("Порядковый номер месяца не может быть меньше 1. Ввведите заново.");
                    if (Month > 12) Console.WriteLine("Порядковый номер месяца не может быть больше 12. Введите заново.");
                } catch (FormatException Error) { Month = 0; Console.WriteLine("Введите число!"); }
            } while ((Month < 1) || (Month > 12));

            // Вводим мин и макс температуру и считаем среднюю температуру
            Console.Write("Укажите минимальную температуру(по умолчанию -40С): ");
            var MinTempEntered = Console.ReadLine();
            int MinTemp;
            try { MinTemp = Int32.Parse(MinTempEntered); } catch (FormatException Error) { MinTemp = -40; }
            if (MinTemp < -40) { MinTemp = -40; }

            Console.Write("Укажите максимальную температуру(по умолчанию +60С): ");
            var MaxTempEntered = Console.ReadLine();
            int MaxTemp;
            try { MaxTemp = Int32.Parse(MaxTempEntered); } catch (FormatException Error) { MaxTemp = 60; }
            if (MaxTemp > 60) { MaxTemp = 60; }

            int MiddleTemp = (MinTemp + MaxTemp) / 2;

            Season MySeason = Season.NoSeason;
            
            // Определяем сезщоны
            if ((Month == 1) || (Month == 2) || (Month == 12)) MySeason = Season.Winter;
            if ((Month == 3) || (Month == 4) || (Month == 5)) MySeason = Season.Spring;
            if ((Month == 6) || (Month == 7) || (Month == 8)) MySeason = Season.Summer;
            if ((Month == 9) || (Month == 10) || (Month == 11)) MySeason = Season.Autumn;

            if ((MySeason == Season.Winter) & (MiddleTemp > 0)) Console.WriteLine("Дождливая зима.");

            Console.WriteLine(); Console.Write("Нажмите любую клавишу..."); Console.ReadKey();

        }
    }
}
