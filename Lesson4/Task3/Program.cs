using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3 {
    class Program {
        enum Season {
            Spring,
            Summer,
            Autumn,
            Winter,
            NoSeason
        }
        static Season CurrentSeason (int Month) {
            switch (Month) {
                case 1: return Season.Winter;
                case 2: return Season.Winter;
                case 3: return Season.Spring;
                case 4: return Season.Spring;
                case 5: return Season.Spring;
                case 6: return Season.Summer;
                case 7: return Season.Summer;
                case 8: return Season.Summer; 
                case 9: return Season.Autumn; 
                case 10: return Season.Autumn;
                case 11: return Season.Autumn;
                case 12: return Season.Winter;
                default: return Season.NoSeason;
            }
        }

        static string SeasonRus(Season CurSeason) {
            switch (CurSeason) {
                case Season.Spring : return "Весна";
                case Season.Summer: return "Лето";
                case Season.Autumn: return "Осень";
                case Season.Winter: return "Зима";
                default: return "\0";
            }
        }
        static void Main(string[] args) {

            int MonthNumber = 0;

            do {
                Console.Write("Enter Month (numbers from 1 to 12): ");
                var MonthEntered = Console.ReadLine();
                try {
                    MonthNumber = Int32.Parse(MonthEntered);
                    if (MonthNumber < 1) Console.WriteLine("Month number must be more than 1. Enter again.");
                    if (MonthNumber > 12) Console.WriteLine("Month number must be lower than 12. Enter again");
                }
                catch (FormatException Error) { MonthNumber= 0; Console.WriteLine("Введите число!"); }
            } while ((MonthNumber < 1) || (MonthNumber > 12));

            Console.WriteLine();
            Console.WriteLine(SeasonRus(CurrentSeason(MonthNumber)));

            Console.WriteLine(); Console.Write("Press any key to exit..."); Console.ReadKey();
        }
    }
}
