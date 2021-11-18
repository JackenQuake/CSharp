using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
//using System.Text.Json.Serialization;
using System.Xml.Serialization;
//using Json.NET;
using System.Runtime.Serialization.Formatters.Binary;

namespace L3T5 {
    [Serializable]
    public class ToDo {
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public void PrintToConsole(int Num) {
            string flag = IsDone ? "[x]" : "   ";
            Console.WriteLine($"{Num,5}: {flag} {Title}");
        }
        public void InputFromConsole() {
            Console.Write("Please enter Title: ");
            Title = Console.ReadLine();
            IsDone = false;
        }
    }
    class Program {
        enum FileFormat {
            json,
            xml,
            bin
        }
        private static string version = "1.0";
        private static string myFile;
        private static int CurTasks, MaxTasks;
        private static ToDo[] tasks;
        private static FileFormat CurFormat;
        private static void LoadTasks() {
            switch (CurFormat) {
                case FileFormat.json:
                    string[] json = File.ReadAllLines(myFile);
                    CurTasks = json.Length;
                    for (int i = 0; i < CurTasks; i++) tasks[i] = JsonSerializer.Deserialize<ToDo>(json[i]);
                    break;
                case FileFormat.xml:
                    /*string[] xml = File.ReadAllLines(myFile);
                    CurTasks = xml.Length / 5;
                    for (int i = 0; i < CurTasks; i++) {
                        string xmlStr = xml[i * 5] + "\n" + xml[i * 5 + 1] + "\n" + xml[i * 5 + 2] + "\n" + xml[i * 5 + 3] + "\n" + xml[i * 5 + 4] + "\n";
                        StringReader stringReader = new StringReader(xmlStr);
                        XmlSerializer serializer = new XmlSerializer(typeof(ToDo));
                        tasks[i] = (ToDo)serializer.Deserialize(stringReader);
                    }*/
                    string xml = File.ReadAllText(myFile);
                    StringReader stringReader = new StringReader(xml);
                    XmlSerializer serializer = new XmlSerializer(typeof(ToDo[]));
                    ToDo[] tmp = (ToDo[])serializer.Deserialize(stringReader);
                    CurTasks = tmp.Length;
                    for (int i = 0; i < CurTasks; i++) tasks[i] = tmp[i];
                    break;
                case FileFormat.bin:
                    BinaryFormatter formatter = new BinaryFormatter();
                    var FStream = new FileStream(myFile, FileMode.Open);
                    tasks = (ToDo[])formatter.Deserialize(FStream);
                    FStream.Close();
                    for (CurTasks = 0; tasks[CurTasks] != null; CurTasks++) ;
                    break;
            }
        }
        private static void SaveTasks() {
            if (File.Exists(myFile)) File.Delete(myFile);
            switch (CurFormat) {
                case FileFormat.json:
                    for (int i = 0; i < CurTasks; i++) {
                        string json = JsonSerializer.Serialize<ToDo>(tasks[i]);
                        File.AppendAllText(myFile, json + "\n");
                    }
                    break;
                case FileFormat.xml:
                    /*for (int i = 0; i < CurTasks; i++) {
                        StringWriter stringWriter = new StringWriter();
                        XmlSerializer serializer = new XmlSerializer(typeof(ToDo));
                        serializer.Serialize(stringWriter, tasks[i]);
                        string xml = stringWriter.ToString();
                        File.AppendAllText(myFile, xml + "\n");
                    }*/
                    ToDo[] tmp = new ToDo[CurTasks];
                    for (int i = 0; i < CurTasks; i++) tmp[i] = tasks[i];
                    StringWriter stringWriter = new StringWriter();
                    XmlSerializer serializer = new XmlSerializer(typeof(ToDo[]));
                    serializer.Serialize(stringWriter, tmp);
                    string xml = stringWriter.ToString();
                    File.AppendAllText(myFile, xml + "\n");
                    break;
                case FileFormat.bin:
                    BinaryFormatter formatter = new BinaryFormatter();
                    FileStream FStream = new FileStream(myFile, FileMode.OpenOrCreate);
                    formatter.Serialize(FStream, tasks);
                    FStream.Close();
                    break;
            }
        }
        private static void ChangeFile() {
            Console.WriteLine("Please enter File format:");
            Console.WriteLine("1. Json-format. Open tasks.json file.");
            Console.WriteLine("2. Xml-format. Open tasks.xml file.");
            Console.WriteLine("3. Bin-format. Open tasks.bin file.");
            bool Error;
            do {
                Error = false;
                Console.Write("Choose format :> ");
                switch (Console.ReadLine()) {
                    case "1": CurFormat = FileFormat.json; myFile = "tasks.json"; break;
                    case "2": CurFormat = FileFormat.xml; myFile = "tasks.xml"; break;
                    case "3": CurFormat = FileFormat.bin; myFile = "tasks.bin"; break;
                    default: Console.WriteLine("Enter number from 1 to 3."); Error = true; break;
                }
            } while (Error);
            if (!File.Exists(myFile)) return;
            Console.WriteLine($"File {Path.GetFullPath(myFile)} already exists. It will be overwritten.");
            do {
                Console.Write("Do you want to reload data from it (you will lose your current edits) [Y/N] :> ");
                switch (Console.ReadLine()) {
                    case "Y":
                    case "y": LoadTasks(); return;
                    case "N":
                    case "n": return;
                    default: Console.WriteLine("Please enter 'Y' or 'N' button."); break;
                }
            } while (true);
        }
        private static void PrintTasks() {
            Console.WriteLine();
            for (int i = 0; i < CurTasks; i++) tasks[i].PrintToConsole(i + 1);
        }
        private static void AddNewTask() {
            Console.WriteLine();
            if (CurTasks == MaxTasks) Console.WriteLine($"Sorry, maximum tasks ({MaxTasks}) for <{myFile}> reached. Please make new file.");
            else {
                tasks[CurTasks] = new ToDo();
                tasks[CurTasks].InputFromConsole();
                CurTasks++;
            }
        }
        private static int SelectTask(string Request) {
            int TaskNumber;
            if (CurTasks == 0) {
                Console.WriteLine("There are no tasks...");
                return -1;
            }
            PrintTasks();
            do {
                Console.Write(Request + " or 0 to cancel :> ");
                try {
                    TaskNumber = Int32.Parse(Console.ReadLine());
                    if ((TaskNumber >= 0) && (TaskNumber <= CurTasks)) return TaskNumber - 1;
                    Console.WriteLine($"Please enter number between 0 and {CurTasks}");
                }
                catch { Console.WriteLine("Task number must be number!"); }
            } while (true);
        }
        private static void DeleteTask() {
            int tmp = SelectTask("Choose task to be deleted");
            if (tmp < 0) return;
            CurTasks--;
            for (; tmp < CurTasks; tmp++) tasks[tmp] = tasks[tmp + 1];
        }
        private static void MarkTaskCompleted() {
            int tmp = SelectTask("Choose task to be marked 'completed'");
            if (tmp >= 0) tasks[tmp].IsDone = true;
        }
        public static void Main(string[] args) {
            MaxTasks = 1024; CurTasks = 0;
            tasks = new ToDo[MaxTasks];
            myFile = "tasks.json";
            if (File.Exists(myFile)) { CurFormat = FileFormat.json; LoadTasks(); }
            else {
                myFile = "tasks.xml";
                if (File.Exists(myFile)) { CurFormat = FileFormat.xml; LoadTasks(); }
                else {
                    myFile = "tasks.bin";
                    if (File.Exists(myFile)) { CurFormat = FileFormat.bin; LoadTasks(); }
                    else {
                        myFile = "tasks.json";
                        CurFormat = FileFormat.json;
                        Console.WriteLine("No default file found. No tasks loaded. Default file set to tasks.json");
                    }
                }
            }
            do {
                Console.WriteLine($"ToDo-List Manager v{version}");
                Console.WriteLine("Copyright (C) Jacken Quake, 2021. ");
                Console.WriteLine("Main menu:");
                Console.WriteLine($"1. Change file <{Path.GetFullPath(myFile)}>.");
                Console.WriteLine("2. Print task list.");
                Console.WriteLine("3. Add new task.");
                Console.WriteLine("4. Delete task.");
                Console.WriteLine("5. Mark task completed.");
                Console.WriteLine("6. Exit. Or press 'X'.");
                Console.Write("Your command :> ");
                switch (Console.ReadLine()) {
                    case "1": ChangeFile(); break;
                    case "2": PrintTasks(); break;
                    case "3": AddNewTask(); break;
                    case "4": DeleteTask(); break;
                    case "5": MarkTaskCompleted(); break;
                    case "6":
                    case "x":
                    case "X": SaveTasks(); return;
                    default: Console.WriteLine("\nUnknown command..."); break;
                }
                Console.WriteLine();
            } while (true);
        }
    }
}
