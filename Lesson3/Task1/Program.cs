using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1 {
    class Program {
        static void PrintNumber(int Spaces, int NumberToPrint) { // Printing number with some spaces before it
            for (int i = 0; i < Spaces; i++) Console.Write(" ");
            Console.WriteLine(NumberToPrint);
        }
        static void Main(string[] args) {

            int N = 5; // rows
            int M = 5; // columns

            var array = new int[N, M];

            // Fill the Matrix
            var rnd = new Random();
            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++) array[i, j] = rnd.Next(9);

            // Printing matrix on screen
            for(int i = 0; i < N; i++) {
                for (int j = 0; j < M; j++) Console.Write(array[i, j]+ " ");
                Console.WriteLine();
            }

            Console.WriteLine();

            // Outputs
            //for (int i = 0; ((i < N) && (i < M)); i++) PrintNumber(i, array[i, i]); // Diagonal Output
            for (int i = 0; ((i < N) && (i < M)); i++) PrintNumber(2*i, array[i, i]); // Diagonal Output *double spaces
            //for (int i = 0; ((i < N) && (i < M)); i++) Console.Write(array[i, i] + " "); // Row Output
            //for (int i = 0; ((i < N) && (i < M)); i++) Console.WriteLine(array[i, i]); // Column Output

            Console.WriteLine(); Console.Write("Press any key to exit..."); Console.ReadKey();
        }
    }
}
