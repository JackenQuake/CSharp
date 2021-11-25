using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task {
    class Program {
        static void Main(string[] args) {
            Console.Write("Please enter your name or nothing to welcome World :> ");
            string str = Console.ReadLine();
            Console.WriteLine();
            if (str == "") str = "World!";
            else str += "!";
            Console.WriteLine("Hello, " + str);
            Console.WriteLine(); Console.Write("Press any key to continue..."); Console.ReadKey();
        }
    }
}
