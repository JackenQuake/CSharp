using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Укажите Ваше имя: ");
            var name = Console.ReadLine();
            Console.WriteLine($"Привет, {name}, сегодня {DateTime.Now}");

//            Console.WriteLine("Нажмите любую клавишу...");
//            Console.ReadKey();
        }
    }
}
