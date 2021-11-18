using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task4ListBasrd {
    class Program {
        private static string myfile;
        private static void ScanFolder(string Path) {
            int MaxFldrs = 1000000;
            int CurrFldr, NumFldrs;
            string[] FldrsList = new string[MaxFldrs];
            string[] CurrList;

            NumFldrs = 1; FldrsList[0] = Path;
            for (CurrFldr = 0; CurrFldr < NumFldrs; CurrFldr++) {
                CurrList = Directory.GetDirectories(FldrsList[CurrFldr]);
                for (int i = 0; i < CurrList.Length; i++) {
                    Console.WriteLine(CurrList[i]);
                    File.AppendAllText(myfile, CurrList[i] + "\n");
                    if (NumFldrs == MaxFldrs) { Console.WriteLine("Error: too many Folders"); return; }
                    FldrsList[NumFldrs++] = CurrList[i];
                }
                CurrList = Directory.GetFiles(FldrsList[CurrFldr]);
                for (int i = 0; i < CurrList.Length; i++) File.AppendAllText(myfile, CurrList[i] + "\n");
            }
        }
        static void Main(string[] args) {
            myfile = "Catalogue.txt";
            Console.Write("Please enter path to folder: ");
            var PathToFolder = Console.ReadLine();
            if (File.Exists(myfile)) File.Delete(myfile);

            try {
                ScanFolder(PathToFolder);
            }
            catch {
                Console.WriteLine("Error scanning tree...");
            };

            Console.WriteLine(); Console.Write("Press any key to exit.."); Console.ReadKey();

        }
    }
}
