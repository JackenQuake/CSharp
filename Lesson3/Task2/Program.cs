using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2 {
    class Program {
        static void Main(string[] args) {

            int amount = 5; // Amount of records
            var Contacts = new string[amount, 2];

            // Entering from keyboard
            /*
            for (int i = 0; i < amount; i++) {
                Console.Write($"Введите {i+1}-ую фамилию: "); Contacts[i, 0] = Console.ReadLine();
                Console.Write($"Введите телефон {Contacts[i,0]}: "); Contacts[i, 1] = Console.ReadLine();
            };
            */    

            // Because I'm too lazy to input it every time)
            Contacts[0, 0] = "Городсков А.В."; Contacts[0, 1] = "8(499)123 4455 / gorodskov@abra-kadabra.com";
            Contacts[1, 0] = "Номеров Н.Т."; Contacts[1, 1] = "8(495)554 4332 / nomerov@abra-kadabra.com";
            Contacts[2, 0] = "Билайнов Г.А."; Contacts[2, 1] = "+7(903)222 3344 / belinov@beeline.beeline";
            Contacts[3, 0] = "Мегафонов Д.И."; Contacts[3, 1] = "+7(902)777 9933 / megafonov@megafon.megafon";
            Contacts[4, 0] = "Бесплатнов Я.М."; Contacts[4, 1] = "8(800)555 3535 / besplatnov@halyavi.net";

            for (int i = 0; i < amount; i++) Console.WriteLine($"{Contacts[i, 0],-20}" + " : " + $"{Contacts[i, 1],50}");

            Console.WriteLine(); Console.Write("Press any key to continue..."); Console.ReadKey();

        }
    }
}
