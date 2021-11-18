using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4 {
    class Program {
        static int FibonacciNumber(int Counter) {
            if (Counter < 2) return (Counter);
            return (FibonacciNumber(Counter - 2) + FibonacciNumber(Counter - 1));
        }
        static void Main(string[] args) {

            //for (int i=0; i<15; i++) Console.Write (FibonacciNumber(i)+" ");
            // 0 1 1 2 3 5 8 13 21 34 55 89 144 233 377 610 987 1597 2584 4181 6765 10946 17711

            int FN = 1;

            Console.Write("Press enter number to count Fibonacci Number: ");
            var FNE = Console.ReadLine();
            try { FN = Int32.Parse(FNE); } catch (FormatException Error) { FN = 1; }

            Console.WriteLine();
            Console.Write($"{FN}-th Fibonacci Number is equal: ");

            /*
            //Non-Recursive approach is much more efficient to calculate Fibonacci Number
            long a=0, b=1, c=1;
            for (int i = 2; i <= FN; i++){
                c = a + b; a = b; b = c;
            }
            if (FN != 0) Console.WriteLine(c);
            else Console.WriteLine("0");
            */

            Console.WriteLine(FibonacciNumber(FN));

            Console.WriteLine(); Console.Write("Press any key to exit..."); Console.ReadKey();
        }
    }
}
