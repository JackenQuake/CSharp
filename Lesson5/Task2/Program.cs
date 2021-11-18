using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2 {
    class Program {
        static void Main(string[] args) {
            string myFile = "startup.txt";
            File.AppendAllText(myFile,DateTime.Now.ToLongTimeString() + "\n");
            Console.WriteLine(); Console.Write("Press any key to exit..."); Console.ReadKey();
        }
    }
}
