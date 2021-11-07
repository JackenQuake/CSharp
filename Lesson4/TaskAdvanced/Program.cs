using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskAdvanced {
    class Program {
        static string SubStringSearch(string str1, string str2) {
            int maxLen = 0, maxPos = 0, i, j, k;
            for (i = 0; i < str1.Length; i++)
                for (j = 0; j < str2.Length; j++) {
                    for (k = 0; (i+k < str1.Length) && (j+k < str2.Length); k++)
                        if (str1[i + k] != str2[j + k]) break;
                    if (k > maxLen) {
                        maxLen = k;
                        maxPos = i;
                    }
                }

            var substr = new char[maxLen];
            for (i = 0; i < maxLen; i++) substr[i] = str1[i + maxPos];
            return new string(substr);

            //return str1.Substring(maxPos, maxLen);
        }
        static void Main(string[] args) {

            string string1, string2;

            Console.Write("Enter 1st string: ");
            string1 = Console.ReadLine();
            Console.Write("Enter 2nd string: ");
            string2 = Console.ReadLine();

            Console.Write("Max substring in both strings is: ");
            Console.WriteLine(SubStringSearch(string1,string2));
            
            Console.WriteLine(); Console.Write("Press any key to exit..."); Console.ReadKey();
        }
    }
}
