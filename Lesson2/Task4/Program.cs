using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4 {
    class Program {
        static void PrintCentered(string Str, int Width) { // Функция центрирует текст внутри строки заданной ширины
            int N = (Width - Str.Length) / 2;
            Console.Write("|");
            for (int i=0; i < N; i++) Console.Write(" ");
            Console.Write(Str);
            N = Width - Str.Length - N;
            for (int i = 0; i < N; i++) Console.Write(" ");
            Console.WriteLine("|");
        }
        static void PrintWithDots(string Str1, string Str2, int Width) { // Функция ставит между 2 строками нужное число точек - для красоты
            Console.Write("|");
            Console.Write(Str1);
            for (int i = 0; i < (Width - (Str1.Length + Str2.Length)); i++) Console.Write("."); 
            Console.Write(Str2);
            Console.WriteLine("|");
        }
        static void PrintProductInfo(int Num, string Str, int amount, double price, int Width) { // Выводим информацию о продукте, использя 2 вспомогательные функции - для красоты)
            Console.Write("|"); for (int i = 0; i <= Width - 1; i++) Console.Write("_"); Console.WriteLine("|");
            PrintWithDots($"     Товар {Num} ", $" {Str}     ", Width); ;
            PrintWithDots("     Колличество ", $" {amount} шт.     ", Width);
            PrintWithDots("     Цена (за штуку)", $" {price:F2} руб.     ", Width);
            PrintWithDots($"     Общая цена за товар {Num} ", $" {amount*price:F2} руб.     ", Width); ;
        }
        static void Main(string[] args) {

            Random Rnd = new Random();

            int CheckWidth = 50; //                            Ширина ЧЕКА

            int MagazineCODE = Rnd.Next(50); //                Номер Магазина
            int CheckNumber = Rnd.Next(10000); //              Номер Чека
            string SellerName = "Пупкин"; //                   Фамилия кассира
            string Product1 = "Название1"; //                  название товара 1
            string Product2 = "Название2"; //                  Название товара 2
            string Product3 = "Название3"; //                  Название товара 3
            string Product4 = "Название4"; //                  Название товара 4
            string Product5 = "Название5"; //                  Название товара 5
            int amount1 = 1 + Rnd.Next(9); //                  Колличество 1 товара
            int amount2 = 1 + Rnd.Next(9); //                  Колличество 2 товара
            int amount3 = 1 + Rnd.Next(9); //                  Колличество 3 товара
            int amount4 = 1 + Rnd.Next(9); //                  Колличество 4 товара
            int amount5 = 1 + Rnd.Next(9); //                  Колличество 5 товара
            double price1 = Rnd.Next(100000) / 100.0; //       Цена 1 товара
            double price2 = Rnd.Next(100000) / 100.0; //       Цена 2 товара
            double price3 = Rnd.Next(100000) / 100.0; //       Цена 3 товара
            double price4 = Rnd.Next(100000) / 100.0; //       Цена 4 товара
            double price5 = Rnd.Next(100000) / 100.0; //       Цена 5 товара

            Console.Write(" "); for (int i = 0; i <= CheckWidth - 1; i++) Console.Write("_"); Console.WriteLine(" ");
            PrintCentered($"Магазин № {MagazineCODE}", CheckWidth);
            PrintCentered($"Чек № {CheckNumber}", CheckWidth);
            PrintCentered($"Кассир: {SellerName}", CheckWidth);
            PrintProductInfo(1, Product1, amount1, price1, CheckWidth);
            PrintProductInfo(2, Product2, amount2, price2, CheckWidth);
            PrintProductInfo(3, Product3, amount3, price3, CheckWidth);
            PrintProductInfo(4, Product4, amount4, price4, CheckWidth);
            PrintProductInfo(5, Product5, amount5, price5, CheckWidth);
            Console.Write("|"); for (int i = 0; i <= CheckWidth - 1; i++) Console.Write("_"); Console.WriteLine("|");

            double TotalPrice = amount1 * price1 + amount2 * price2 + amount3 * price3 + amount4 * price4 + amount5 * price5;

            Console.Write("|"); for (int i = 0; i <= CheckWidth - 1; i++) Console.Write(" "); Console.WriteLine("|");
            PrintWithDots($"     Общая цена. ИТОГ : ", $" {TotalPrice:F2} руб.     ", CheckWidth); ;
            Console.Write("|"); for (int i = 0; i <= CheckWidth - 1; i++) Console.Write("_"); Console.WriteLine("|");

            for (int i = 0; i <= 2; i++) Console.WriteLine();
            Console.Write("Нажмите любую клавишу...");
            Console.ReadKey();

        }
    }
}
