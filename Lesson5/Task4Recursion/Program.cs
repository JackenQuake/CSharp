using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task4 {
    class Program {
        static string myfile;
        private static void ScanFolder(string Folder,int lvl) {
            
            string[] files = Directory.GetFiles(Folder);
            string[] directories = Directory.GetDirectories(Folder);
         
            //adding spaces for beauty
            char[] arr = new char[lvl];
            for (int i = 0; i < lvl; i++) arr[i] = ' ';
            string filler = new string(arr);
            
            //catching directories
            for (int i = 0; i < directories.Length; i++) {
                Console.WriteLine(filler + directories[i]);
                File.AppendAllText(myfile, filler + directories[i] + "\n");
                ScanFolder(directories[i], lvl + 1);
            }
            
            //catching files
            for (int i = 0; i < files.Length; i++) {
                //Console.WriteLine(files[i]);
                File.AppendAllText(myfile, filler + files[i] + "\n");
            }
        }
        static void Main(string[] args) {
            myfile = "Catalogue.txt";
            Console.Write("Please enter path to folder: ");
            var PathToFolder = Console.ReadLine();
            if (File.Exists(myfile)) File.Delete(myfile);

            try {
                ScanFolder(PathToFolder, 0);
            } catch {
                Console.WriteLine("Error scanning tree...");
            };

            Console.WriteLine(); Console.Write("Press any key to exit.."); Console.ReadKey();
        }
    }
}
