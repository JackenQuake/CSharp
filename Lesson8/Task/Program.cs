using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task {
    class Program {
        static void Main(string[] args) {
            bool NeedSave = false;
            string Greeting = Properties.Settings.Default.Greeting;
            if (string.IsNullOrEmpty(Properties.Settings.Default.Name)) {
                Console.WriteLine($"{Greeting}, new and yet unknown user!");
                Console.Write("Please enter your name :> ");
                Properties.Settings.Default.Name = Console.ReadLine();
                NeedSave = true;
            }
            else {
                Console.Write($"{Greeting}, {Properties.Settings.Default.Name}!");
                Console.Write(" Is this you? (y/N) :> ");
                if (Console.ReadLine() != "y") {
                    Console.Write("Please enter your name :> ");
                    Properties.Settings.Default.Name = Console.ReadLine();
                    Properties.Settings.Default.Age = 0;
                    Properties.Settings.Default.Occupation = "";
                    NeedSave = true;
                }
            }
            if (Properties.Settings.Default.Age == 0) {
                Console.Write("Please enter your age :> ");
                try { Properties.Settings.Default.Age = Int32.Parse(Console.ReadLine()); } 
                catch { Console.WriteLine("Incorrect age. Age set to 0. You will be asked again on next launch."); }
                NeedSave = true;
            }
            else Console.WriteLine($"Your age is: {Properties.Settings.Default.Age}.");
            if (string.IsNullOrEmpty(Properties.Settings.Default.Occupation)) {
                Console.Write("Please enter your occupation :> ");
                Properties.Settings.Default.Occupation = Console.ReadLine();
                NeedSave = true;
            }
            else Console.WriteLine($"Your occupation is: {Properties.Settings.Default.Occupation}.");
            if (NeedSave) Properties.Settings.Default.Save();
            Console.WriteLine(); Console.Write("Press any key to exit..."); Console.ReadKey();
        }
    }
}
