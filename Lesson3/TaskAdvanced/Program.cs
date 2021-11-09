using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskAdvanced {
    class SeaBattleField {
        char[,] Field;
        int Size;
        Random rnd;
        public SeaBattleField(int FieldSize) {
            Size = FieldSize;
            Field = new char[Size, Size];
            ClearField();
            rnd = new Random();
        }
        public void ClearField() {
            for (int j = 0; j < Size; j++)
                for (int i = 0; i < Size; i++) Field[i, j] = 'O';
        }
        public void PrintField() {
            for (int j = 0; j < Size; j++) {
                for (int i = 0; i < Size; i++) Console.Write(Field[i, j] + " ");
                Console.WriteLine(" ");
            }
        }
        private bool CellHasX(int x, int y) {
            if ((x < 0) || (y < 0) || (x >= Size) || (y >= Size)) return false;
            return (Field[x, y] == 'X');
        }
        private bool CellAvailable(int x, int y) {
            if ((x < 0) || (y < 0) || (x >= Size) || (y >= Size)) return false;
            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++) if (CellHasX(x + i, y + j)) return false;
            return true ;
        }
        public bool PutShip(int x, int y, int ShipSize, bool Vertical) {
            int Dx = 0 , Dy = 0 ;
            if (Vertical) Dy = 1; else Dx = 1;
            for (int i = 0; i < ShipSize; i++) if (!CellAvailable(x + i * Dx, y + i * Dy)) return false;
            for (int i = 0; i < ShipSize; i++) Field[x + i * Dx, y + i * Dy] = 'X';
            return true;
        }
        public bool PutShipRandomly(int ShipSize, int Retries) {
            for (int i = 0; i < Retries; i++) {
                int x = rnd.Next(Size); 
                int y = rnd.Next(Size);
                bool Vertical = rnd.Next(2) > 0;
                if (PutShip(x, y, ShipSize, Vertical)) return true;
            }
            return false;
        }
        public bool MakeRandomShipsAttempt() {
            ClearField();
            //if (!PutShipRandomly(5, 10)) return false;
            for (int i = 0; i < 1; i++) if (!PutShipRandomly(4, 10)) return false;
            for (int i = 0; i < 2; i++) if (!PutShipRandomly(3, 10)) return false;
            for (int i = 0; i < 3; i++) if (!PutShipRandomly(2, 10)) return false;
            for (int i = 0; i < 4; i++) if (!PutShipRandomly(1, 10)) return false;
            return true;
        }
        public bool MakeRandomShips(int Retries) {
            for (int i = 0; i < Retries; i++) if (MakeRandomShipsAttempt()) return true;
            return false;
        }
    }
    class Program {
        static void Main(string[] args) {

            int FieldSize = 10;
            var Field = new SeaBattleField(FieldSize);

            if (!Field.MakeRandomShips(10)) Console.WriteLine("Failed to create field...");
            else Field.PrintField();


            // or we can simply - make static field
            /*
            Console.WriteLine();
            var field = new char[10, 10] {
                {'O','O','O','O','O','O','O','O','O','O'},
                {'O','X','O','O','X','O','O','O','X','O'},
                {'O','X','O','O','O','O','O','O','O','O'},
                {'O','X','O','O','O','O','O','O','O','O'},
                {'O','O','O','X','O','O','X','X','O','O'},
                {'O','O','O','O','O','O','O','O','O','O'},
                {'X','O','O','O','O','O','O','O','O','X'},
                {'X','O','X','X','O','X','O','X','O','X'},
                {'O','O','O','O','O','O','O','O','O','X'},
                {'O','X','X','X','X','O','O','O','O','O'},
            };

            for (int i = 0; i < 10; i++) {
                for (int j = 0; j < 10; j++) Console.Write(field[i, j] + " ");
                Console.WriteLine(" ");
            };
            */

            Console.WriteLine(); Console.Write("Press any key to exit..."); Console.ReadKey();

        }
    }
}
