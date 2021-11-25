// Decompiled with JetBrains decompiler
// Type: Task.Program
// Assembly: Task, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8E104701-6224-419B-9C78-1C0D4D77E6DE
// Assembly location: C:\Work\GeekBrains\CSharp\Lesson7\Task.exe

using System;

namespace Task {
    internal class Program {
        private static void Main(string[] args) {
            Console.WriteLine("Task modified by dotPeek...");
            Console.Write("Please enter your name or nothing to welcome World :> ");
            string str = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Hello, " + (!(str == "") ? str + "!" : "World!"));
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
