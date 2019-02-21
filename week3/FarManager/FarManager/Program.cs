using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FarManager
{
    class Program
    {
        const string ROOT_DIR = "..\\..\\..\\Test";

        // Задаем константы для цветов
        const ConsoleColor DIR_COLOR = ConsoleColor.Green;
        const ConsoleColor FILE_COLOR = ConsoleColor.Yellow;
        const ConsoleColor SEL_BGCOLOR = ConsoleColor.Blue;
        const ConsoleColor DEF_BGCOLOR = ConsoleColor.Black;
        const ConsoleColor DEF_COLOR = ConsoleColor.White;

        // Вывод списка файлов м каталогов
        static List<object> Print(DirectoryInfo paramDir, int paramCurrent)
        {
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine("Press [ESC] to stop, [Enter] to enter/open txt, [BackSpace] to return, [Delete] to delete\n");

            Console.ForegroundColor = DIR_COLOR;
            Console.BackgroundColor = DEF_BGCOLOR;

            List<object> l = new List<object>();
            int k = 0;
            // Вывод списка директориев
            foreach (DirectoryInfo d in paramDir.GetDirectories())
            {
                if (k == paramCurrent)
                    Console.BackgroundColor = SEL_BGCOLOR;
                else
                    Console.BackgroundColor = DEF_BGCOLOR;
                Console.WriteLine((k+1) + ". " + d.Name);
                l.Add(d);
                k++;
            }
            Console.ForegroundColor = FILE_COLOR;
            // Вывод списка файлов
            foreach (FileInfo f in paramDir.GetFiles())
            {
                if (k == paramCurrent)
                    Console.BackgroundColor = SEL_BGCOLOR;
                else
                    Console.BackgroundColor = DEF_BGCOLOR;
                Console.WriteLine((k + 1) + ". " + f.Name);
                l.Add(f);
                k++;
            }
            Console.ForegroundColor = DEF_COLOR;
            Console.BackgroundColor = DEF_BGCOLOR;
            return l;
        }

        // Вывод текстовых файлов
        static void PrintFile(FileInfo file)
        {
            string text = System.IO.File.ReadAllText(file.FullName);
            System.Console.WriteLine(text);
        }

        static void Main(string[] args)
        {
            int count;
            int curr = 0;
            ConsoleKey ch = 0;

            DirectoryInfo dir = new DirectoryInfo(ROOT_DIR);
            List<object> dirInfoList = Print(dir, curr);
            count = dirInfoList.Count;

            while (!Console.KeyAvailable && ch != ConsoleKey.Escape)
            {
                // Do something
                ch = Console.ReadKey(true).Key;
                switch (ch)
                {
                    // Вверх
                    case ConsoleKey.UpArrow:
                        if (curr > 0) curr--;
                        Print(dir, curr);
                        break;
                    // Вниз
                    case ConsoleKey.DownArrow:
                        if (curr < count - 1) curr++;
                        Print(dir, curr);
                        break;
                    // Вход в папку
                    case ConsoleKey.Enter:
                        if (dirInfoList[curr] is DirectoryInfo)
                        {
                            dir = (DirectoryInfo)dirInfoList[curr];
                            curr = 0;
                            dirInfoList = Print(dir, curr);
                            count = dirInfoList.Count;
                        }
                        else
                        {
                            var f = (FileInfo)dirInfoList[curr];
                            if (f.Extension == ".txt")
                            {
                                PrintFile(f);
                            }
                        }
                        break;
                    // Выход на уровень выше
                    case ConsoleKey.Backspace:
                        // Защита чтобы не выйти выше корневой папки
                        if (dir.FullName != ROOT_DIR)
                        {
                            dir = dir.Parent;
                            curr = 0;
                            dirInfoList = Print(dir, curr);
                            count = dirInfoList.Count;
                        }
                        break;
                    // Удаление
                    case ConsoleKey.Delete:
                        // Проверка на то, что список не пуст
                        if (count > 0)
                        {
                            try
                            {
                                if (dirInfoList[curr] is DirectoryInfo)
                                {
                                    var obj = (DirectoryInfo)dirInfoList[curr];
                                    Directory.Delete(obj.FullName);
                                }
                                else
                                {
                                    var obj = (FileInfo)dirInfoList[curr];
                                    File.Delete(obj.FullName);
                                }
                                curr = 0;
                                dirInfoList = Print(dir, curr);
                                count = dirInfoList.Count;
                            }
                            catch (IOException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                        break;
                    // Переименовать
                    case ConsoleKey.F6:
                        // Проверка на то, что список не пуст
                        if (count > 0)
                        {
                            Console.Write("Enter new name: ");
                            string newName = Console.ReadLine();
                            try
                            {
                                if (dirInfoList[curr] is DirectoryInfo)
                                {
                                    var obj = (DirectoryInfo)dirInfoList[curr];
                                    Directory.Move(obj.FullName, obj.Parent.FullName + "\\" + newName);
                                }
                                else
                                {
                                    var obj = (FileInfo)dirInfoList[curr];
                                    File.Move(obj.FullName, dir.FullName + "\\" + newName);
                                }
                                curr = 0;
                                dirInfoList = Print(dir, curr);
                                count = dirInfoList.Count;
                            }
                            catch (IOException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                        break;
                }
            }
        }
    }
}
