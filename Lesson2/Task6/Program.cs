using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6 {
    public enum WorkDays {
        Monday =    0b_0000001,
        Tuesday =   0b_0000010,
        Wednesday = 0b_0000100,
        Thursday =  0b_0001000,
        Friday =    0b_0010000,
        Saturday =  0b_0100000,
        Sunday =    0b_1000000
     }

     class Program {
        static void PrintWorkDays(WorkDays W) {
            if ((W & WorkDays.Monday) != (WorkDays)0) Console.Write(" Monday");
            if ((W & WorkDays.Tuesday) != (WorkDays)0) Console.Write(" Tuesday");
            if ((W & WorkDays.Wednesday) != (WorkDays)0) Console.Write(" Wednesday");
            if ((W & WorkDays.Thursday) != (WorkDays)0) Console.Write(" Thursday");
            if ((W & WorkDays.Friday) != (WorkDays)0) Console.Write(" Friday");
            if ((W & WorkDays.Saturday) != (WorkDays)0) Console.Write(" Saturday");
            if ((W & WorkDays.Sunday) != (WorkDays)0) Console.Write(" Sunday");
        }
        static void Main(string[] args) {

            WorkDays Office1 = (WorkDays)0b_0011110;
            WorkDays Office2 = (WorkDays)0b_1111111;

            Console.Write("Office 1 work days:"); PrintWorkDays(Office1); Console.WriteLine();
            Console.Write("Office 2 work days:"); PrintWorkDays(Office2); Console.WriteLine();

            Console.WriteLine(); Console.Write("Нажмите любую клавишу..."); Console.ReadKey();

        }
    }
}
