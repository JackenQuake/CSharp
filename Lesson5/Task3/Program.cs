using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3 {
    class Program {
        private static int EnterNumber(string Request) {
            bool Error = false;
            int Number = 0;
            do {
                Error = false;
                Console.Write(Request);
                var strNumber = Console.ReadLine();
                try {
                    Number = Int32.Parse(strNumber);
                }
                catch {
                    Error = true;
                    Console.WriteLine($"Entered string '{strNumber}' is not NUMBER! Please enter the NUMBER!");
                };
            } while (Error);
            return Number;
        }
        private static byte EnterByte(string Request) {
            int Number;
            do {
                Number = EnterNumber(Request);
                if ((Number >= 0) && (Number <= 255)) return (byte)Number;
                Console.WriteLine($"You entered {Number}. Byte must be from 0 to 255. Enter again please.");
            } while (true);
        }
        static void Main(string[] args) {
            //string myfile = @"C:\Temp\file.bin";
            string myfile = "file.bin";
            int NumberOfNumbers = EnterNumber("Please enter number of numbers: ");
            byte[] Numbers = new byte[NumberOfNumbers];
            for (int i = 0; i < NumberOfNumbers; i++) Numbers[i] = EnterByte($"Please enter byte №{i+1} (number from 0 to 255): ");
            //if (!File.Exists(myfile)) File.Create(myfile).Close();
            File.WriteAllBytes(myfile, Numbers);
            Console.WriteLine(); Console.Write("Press any key to exit..."); Console.ReadKey();
        }
    }
}
