using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskAdvanced {
    public abstract class StringParser {
        protected char Sign1, Sign2;
        protected double InitialValue;
        protected abstract double GetSubstringValue(string Eq);
        protected abstract double UpdateValue(double Value, double CurrValue, char CurrSign);
        public double ProcessString(string Eq) {
            double Value = InitialValue, CurrValue;
            char CurrSign = '\0';
            int i = 0, j, p1, p2;
            do {
                p1 = Eq.IndexOf(Sign1, i); if (p1 < 0) p1 = Eq.Length;
                p2 = Eq.IndexOf(Sign2, i); if (p2 < 0) p2 = Eq.Length;
                j = Math.Min(p1, p2);
                CurrValue = GetSubstringValue(Eq.Substring(i, j - i));
                if (CurrSign == '\0') Value = CurrValue;
                else Value = UpdateValue(Value, CurrValue, CurrSign);
                if (j == Eq.Length) return Value;
                CurrSign = Eq[j]; i = j + 1;
            } while (true);
        }
    }
    public class StringParserMulDiv : StringParser {
        public StringParserMulDiv() {
            Sign1 = '*'; Sign2 = '/'; InitialValue = 1;
        }
        protected override double GetSubstringValue(string Eq) { return Double.Parse(Eq); }
        protected override double UpdateValue(double Value, double CurrValue, char CurrSign) { return (CurrSign == '/') ? (Value / CurrValue) : (Value * CurrValue); }
    }
    public class StringParserAddSub : StringParser {
        private StringParserMulDiv MulDivParser;
        public StringParserAddSub() {
            Sign1 = '+'; Sign2 = '-'; InitialValue = 0;
            MulDivParser = new StringParserMulDiv();
        }
        protected override double GetSubstringValue(string Eq) { return MulDivParser.ProcessString(Eq); }
        protected override double UpdateValue(double Value, double CurrValue, char CurrSign) { return (CurrSign == '-') ? (Value - CurrValue) : (Value + CurrValue); }
    }
    class Program {
        static void Main(string[] args) {
            string Eq;
            if (args.Length > 0) Eq = args[0];
            else {
                Console.Write("Enter your equation: ");
                Eq = Console.ReadLine();
            }
            StringParserAddSub EquationParser = new StringParserAddSub();
            try {
                Console.WriteLine("Answer: " + EquationParser.ProcessString(Eq));
            }
            catch { Console.WriteLine("Equation is incorrect..."); }
            Console.WriteLine(); Console.Write("Press any key to exit..."); Console.ReadKey();
        }
    }
}