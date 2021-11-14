using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1 {
    class Program {
        static void Main(string[] args) {
            Console.Write("Enter any string to write to file: ");
            var str = Console.ReadLine();
            string myFile = "L5T1.txt";
            File.WriteAllText(myFile, str);
            Console.WriteLine(); Console.Write("Press any key to exit..."); Console.ReadKey();
        }
    }
}
