using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskAdvanced {
    class Program {
        static void Main(string[] args) {


            int previous =0 , current =0, total =0;

            bool Error = false; // exception Rome Number

            Console.Write("Введите римское число: ");
            var RomeNumber = Console.ReadLine();

            for (int i = RomeNumber.Length - 1; i >= 0; i--) {

                switch (RomeNumber[i]) {
                    case 'I': current = 1; break;
                    case 'V': current = 5; break;
                    case 'X': current = 10; break;
                    case 'L': current = 50; break;
                    case 'C': current = 100; break;
                    case 'D': current = 500; break;
                    case 'M': current = 1000; break;
                    default: Error = true; break;
                }
                if (current >= previous) total += current;
                else total -= current;
                previous = current;
            }

            Console.WriteLine();
            if (Error) Console.WriteLine("Введенная строка не является римским числом!");
            else Console.WriteLine($"Римское число: {RomeNumber} соответсвует арабскому числу: {total}.");

            for (int i = 0; i <= 2; i++) Console.WriteLine();
            Console.Write("Нажмитк любую клавишу..."); Console.ReadKey();
        }
    }
}
