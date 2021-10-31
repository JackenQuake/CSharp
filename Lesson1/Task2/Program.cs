using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("FizzBuzz test programm.");
            Console.Write("Type max number (Default = 100): ");
            var MXN = Console.ReadLine();
            int MaxNumber;

            try {
                MaxNumber = Int32.Parse(MXN);
            }
            catch (FormatException Error) { MaxNumber = 100; }
            
            if (MaxNumber <= 0) MaxNumber = 100;

            Console.WriteLine($"Lets try UP to {MaxNumber}");

            for (int i = 1; i <= MaxNumber; i++) {
                if (i % 3 == 0) {
                    if (i % 5 == 0) Console.WriteLine("fizz buzz");
                    else Console.WriteLine("fizz");
                }
                else {
                    if (i % 5 == 0) Console.WriteLine("buzz");
                    else Console.WriteLine($"{i}");
                }
            }

            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();

        }
    }
}
