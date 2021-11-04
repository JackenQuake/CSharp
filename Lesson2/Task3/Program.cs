using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2 {
    class Program {
        static void Main(string[] args) {
            int Number;
            Console.Write("Введите число (по умолчанию 1): ");
            var NumberEntered = Console.ReadLine();
            try { Number = Int32.Parse(NumberEntered); } catch (FormatException Error) { Number = 1; }

            if ((Number % 2) == 0) Console.WriteLine($"Число {Number} четно!");
            else Console.WriteLine($"Число {Number} нечетно!");

            Console.Write("Нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}