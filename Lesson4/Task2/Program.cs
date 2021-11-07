using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2 {
    class Program {

        static int SumNumbers(string str) {
            int Sum = 0, i = 0, current = 0;
            for (i = 0; i < str.Length; i++)
                if (str[i] == ' ') {
                    Sum += current;
                    current = 0;
                } else if ((str[i] >= '0') && (str[i]<='9')) current = current*10 + str[i] - '0';
            Sum += current;
            return Sum;
        } 
        static void Main(string[] args) {

            string mystr;
            Console.Write("Please enter numbers separated by spaces: ");
            mystr = Console.ReadLine();
            Console.WriteLine(); 
            Console.WriteLine("Sum of numbers is: " + SumNumbers(mystr));

            Console.WriteLine(); Console.Write("Press any key to exit.."); Console.ReadKey();
        }
    }
}
