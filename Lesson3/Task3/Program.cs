using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3 {
    class Program {
        static void Main(string[] args) {
            
            Console.Write("Type your string: ");
            
            var str = Console.ReadLine();

            char[] trs = new char[str.Length+1];
            for (int i = 0; i < str.Length; i++) trs[i] = str[str.Length - i - 1];
            trs[str.Length] = '\0';
            
            Console.Write("Backward your string: ");
            Console.WriteLine(trs);

            // Or we can simply :
            //for (int i = str.Length; i > 0; i--) Console.Write(str[i - 1]);

            Console.WriteLine(); Console.Write("Press any key to exit..."); Console.ReadKey();

        }
    }
}
