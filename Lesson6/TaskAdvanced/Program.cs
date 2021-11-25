using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TaskAdvanced {
    class Program {
        class Words {
            public string Word;
            public int Freq;
            public Words Next;
            public Words(string _Word) {
                Word = _Word;
                Freq = 1;
                Next = null;
            }
        }
        private static int MaxHash = 32768;
        private static Words[] First;
        static int GetHashofWord(string word) {
            int hash = 0;
            if (word.Length > 0) hash |= ((word[0] & 0x1f) << 10);
            if (word.Length > 1) hash |= ((word[1] & 0x1f) << 5);
            if (word.Length > 2) hash |= ((word[2] & 0x1f) << 0); //same as -> if (word.Length > 2) hash |= (word[2] & 0x1f);
            return hash;
        }
        static void ProcessWord(string word) {
            int Hash = GetHashofWord(word);
            if (First[Hash] == null) { First[Hash] = new Words(word); return; }
            Words Current, Last = First[Hash];
            for (Current = First[Hash]; Current != null; Current = Current.Next) {
                if (Current.Word == word) { Current.Freq++; return; }
                Last = Current;
            }
            Last.Next = new Words(word);
        }
        static void Main(string[] args) {
            //string myFile = "myfile.txt";
            //string myFile = "The_Lord_of_the_Rings.txt";
            Console.Write("Enter File Name :> ");
            string myFile = Console.ReadLine();
            int NumMaxWords = 10; // Max to compare
            string[] strArr;
            int i, j, k;
            try { strArr = File.ReadAllLines(myFile); }
            catch {
                Console.WriteLine("File open error...");
                Console.Write("Press any key to exit..."); Console.ReadKey();
                return;
            }
            First = new Words[MaxHash];
            for (i = 0; i < MaxHash; i++) First[i] = null;
            for (i = 0; i < strArr.Length; i++) {
                for (j = 0; true; j = k + 1) {
                    k = strArr[i].IndexOf(' ', j);
                    if (k < 0) break;
                    if (k > j) ProcessWord(strArr[i].Substring(j, k - j));
                }
                k = strArr[i].Length; if (k > j) ProcessWord(strArr[i].Substring(j, k - j));
            }
            //Okey, this is lazy method to find (NumMaxWords=)10 Maximus. But it works. it can be done with an array of 10 maximums and proper insenrion of new ones... 
            Words Current, MaxWord = null;
            int MaxFreq = 0;
            for (i = 0; i < NumMaxWords; i++) {
                MaxFreq = -1;
                for (j = 0; j < MaxHash; j++)
                    for (Current = First[j]; Current != null; Current = Current.Next) if (Current.Freq > MaxFreq) { MaxFreq = Current.Freq; MaxWord = Current; }
                if (MaxFreq == -1) break;
                Console.WriteLine($"[{MaxWord.Word}] : {MaxWord.Freq}");
                MaxWord.Freq = -1;
            };
            Console.WriteLine(); Console.Write("Press any key to exit..."); Console.ReadKey();
        }
    }
}
