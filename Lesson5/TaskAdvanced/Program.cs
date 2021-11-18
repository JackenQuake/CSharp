using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Backpack solution
namespace TaskAdvanced {
    class Program {
        private static int GetPackedBag(int maxWeight, int[] itemsPrice, int[] itemsWeight) {
            int NumItems, Weight, Price, maxPrice = 0, i;
            NumItems = itemsPrice.Length;
            bool[] Curr = new bool[NumItems]; // Current combination
            bool[] Best = new bool[NumItems]; // Best combination
            for (i = 0; i < NumItems; i++) { Curr[i] = false; Best[i] = false; }
            while (true) {
                // Count size and Weight of current combination
                Weight = 0; Price = 0;
                for (i = 0; i < NumItems; i++)
                    if (Curr[i]) { Weight += itemsWeight[i]; Price += itemsPrice[i]; }
                //Console.WriteLine(Weight + " " + Price);
                // Checking for maximum
                if ((Weight <= maxWeight) && (Price > maxPrice)) {
                    maxPrice = Price; for (i = 0; i < NumItems; i++) Best[i] = Curr[i];
                }
                // Computing new combination - this is essentially adding 1 to binary number
                for (i = 0; i < NumItems; i++) {
                    if (Curr[i]) Curr[i] = false;
                    else { Curr[i] = true; break; }
                }
                // Getting carry past last number means we have reached end
                if (i == NumItems) break;
            }
            return maxPrice;
        }
        private static int EnterInteger(string Request) {
            int Number;
            do {
                Console.Write(Request);
                try {
                    Number = Int32.Parse(Console.ReadLine());
                    if (Number > 0) return Number;
                    Console.WriteLine("Enter positive number (more than 0).");
                } catch { Console.WriteLine("Enter number."); };
            } while (true);
        }
        static void Main() {
            int NumItems, maxWeight;
            NumItems = EnterInteger("Enter number of items :> ");
            int[] itemsWeight = new int[NumItems];   // itemsWeight of all itmes
            int[] itemsPrice = new int[NumItems];    // itemsPrice of all items

            for (int i = 0; i < NumItems; i++) {
                itemsWeight[i] = EnterInteger($"Enter {i+1}'th item weight :> ");
                itemsPrice[i] = EnterInteger($"Enter {i+1}'th item price :> ");
            };
            maxWeight = EnterInteger("Enter max weight of backpack :> ");
            Console.WriteLine("Best backpack has cost: " + GetPackedBag(maxWeight, itemsPrice, itemsWeight));

            Console.WriteLine(); Console.Write("Press any key to exit..."); Console.ReadKey();
        }
    }
}
