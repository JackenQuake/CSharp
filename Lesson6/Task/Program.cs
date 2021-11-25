using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace Task {
    class Program {
        private static string version = "1.0";
        private static Process[] processes;
        //private static Process process;
        private static string Prefix = "";
        public static void ChangePrefix() {
            Console.Write($"Please enter prefix for process. Current: '{Prefix}': > ");
            Prefix = Console.ReadLine();
        }
        public static void ListProcess(bool ToFile) {
            processes = Process.GetProcesses();
            Console.WriteLine();
            if (ToFile) if (File.Exists("process.txt")) File.Delete("process.txt");
            for (int i = 0; i < processes.Length; i++)
                try {
                    if (processes[i].ProcessName.Substring(0, Math.Min(Prefix.Length, processes[i].ProcessName.Length)) == Prefix) Console.WriteLine($"{processes[i].ProcessName,-50} {$"<ID:{processes[i].Id}>",-30} {processes[i].StartTime,10}.");
                    if (ToFile) File.AppendAllText("process.txt", $"{processes[i].ProcessName,-50} {$"<ID:{processes[i].Id}>",-30} {processes[i].StartTime,10}.\n");
                }
                catch {
                    if (processes[i].ProcessName.Substring(0, Math.Min(Prefix.Length, processes[i].ProcessName.Length)) == Prefix) Console.WriteLine($"{processes[i].ProcessName,-50} {$"<ID:{processes[i].Id}>",-30} Access denied: Time Error.");
                    if (ToFile) File.AppendAllText("process.txt", $"{processes[i].ProcessName,-50} {$"<ID:{processes[i].Id}>",-30} Access denied: Time Error.\n");
                }
        }
        public static void KillProcess(Process process) {
            try {
                Console.Write($"A you sure to delete process: {process.ProcessName} <ID:{process.Id}> (Y/N):> ");
                var str = Console.ReadLine();
                if ((str == "y") || (str == "Y")) {
                    Console.WriteLine($"{process.ProcessName} <ID:{process.Id}> killed.");
                    process.Kill();
                }
            }
            catch { Console.WriteLine("Exception happend while trying to kill proccess."); }
        }
        public static void KillProcessByName() {
            ListProcess(false);
            Console.WriteLine();
            Console.Write("Please enter Name of process to kill :> ");
            processes = Process.GetProcessesByName(Console.ReadLine());
            Console.WriteLine();
            foreach (Process process in processes) KillProcess(process);
        }
        public static void KillProcessByID() {
            ListProcess(false);
            int ProcessID = 0;
            Console.WriteLine();
            Console.Write("Please enter ID of process to kill :> ");
            try { ProcessID = Int32.Parse(Console.ReadLine()); } catch { Console.WriteLine("Input error. ID must be a nuber. Back to main menu."); return; };
            Process process = Process.GetProcessById(ProcessID);
            KillProcess(process);
        }
        static void Main(string[] args) {
            do {
                Console.WriteLine($"Task Manager v{version}");
                Console.WriteLine("Copyright (C) Jacken Quake, 2021. ");
                Console.WriteLine("Main menu:");
                Console.WriteLine($"1. Change file prefix (mask to search). Current: '{Prefix}'.");
                Console.WriteLine("2. List all running processes with current prefix.");
                Console.WriteLine("3. Export list of processes to file 'processes.txt'.");
                Console.WriteLine("4. Kill process by Name.");
                Console.WriteLine("5. Kill process by ID.");
                Console.WriteLine("6. Exit. Or press 'X'.");
                Console.Write("Your command :> ");
                switch (Console.ReadLine()) {
                    case "1": ChangePrefix(); break;
                    case "2": ListProcess(false); break;
                    case "3": ListProcess(true); break;
                    case "4": KillProcessByName(); break;
                    case "5": KillProcessByID(); break;
                    case "6":
                    case "x":
                    case "X": return;
                    default: Console.WriteLine("\nUnknown command..."); break;
                }
                Console.WriteLine();
            } while (true);
        }
    }
}
