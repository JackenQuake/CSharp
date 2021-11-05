using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {

//          Min Temp

            Console.Write("Укажите минимальную температуру(по умолчанию -40С): ");
            var MinTempEntered = Console.ReadLine();
            int MinTemp;

            try {
                MinTemp = Int32.Parse(MinTempEntered);
            }
            catch (FormatException Error) { MinTemp = -40; }

            if (MinTemp < -40) { MinTemp = -40; }

//          Max Temp

            Console.Write("Укажите максимальную температуру(по умолчанию +60С): ");
            var MaxTempEntered = Console.ReadLine();
            int MaxTemp;

            try {
                MaxTemp = Int32.Parse(MaxTempEntered);
            }
            catch (FormatException Error) { MaxTemp = 60; }
            
            if (MaxTemp > 60) { MaxTemp = 60; }

            int a = 0;

            if (MinTemp > MaxTemp) { a = MinTemp; MinTemp = MaxTemp; MaxTemp = a; }

            Console.WriteLine($"Минимальная температура = {MinTemp}С");
            Console.WriteLine($"Максимальная температура = {MaxTemp}С");


            Console.WriteLine($"Средняя температура = {((MinTemp + MaxTemp) / 2)}");


//            a = (MinTemp + MaxTemp) / 2;
//            Console.WriteLine($"Средняя температура = {a}");

            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
