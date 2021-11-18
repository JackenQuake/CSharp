using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1 {
    class Program {
        static string GetFullName(string firstName, string lastName, string patronymic) {
             return (firstName + " " + lastName + " " + patronymic);
        }
        static void Main(string[] args) {
            int amount = 3;
            
            // Arrays version
            var Names = new string[amount, 3];

            for (int i=0; i<amount; i++) {
                Console.WriteLine("Person " + (i+1) + " : ");
                Console.Write("  Enter First Name: "); Names[i, 0] = Console.ReadLine();
                Console.Write("  Enter Last Name: "); Names[i, 1] = Console.ReadLine();
                Console.Write("  Enter Patronymic: "); Names[i, 2] = Console.ReadLine();
                Console.WriteLine();
            }
            
            for (int i=0; i<amount; i++) Console.WriteLine(GetFullName(Names[i, 0], Names[i, 1], Names[i, 2]));
           
            // Simplier approach
            /*
            string firstName, lastName, patronymic;

            for (int i = 0; i < amount; i++) {
                Console.WriteLine("Person " + (i + 1) + " : ");
                Console.Write("  Enter First Name: "); firstName = Console.ReadLine();
                Console.Write("  Enter Last Name: "); lastName = Console.ReadLine();
                Console.Write("  Enter Patronymic: "); patronymic = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine(GetFullName(firstName, lastName, patronymic));
                Console.WriteLine();
            }
            */

            Console.WriteLine(); Console.Write("Press any key to exit..."); Console.ReadKey();
        }
    }
}
