using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK3
{
    class Program
    {
        static void PrintDir(DirectoryInfo aDir, int level)
        {
            foreach (FileInfo f in aDir.GetFiles())
            {
                Tabs(level);
                Console.WriteLine(f.Name);  
   
            }
            foreach (DirectoryInfo d in aDir.GetDirectories())
            {
                Tabs(level);
                Console.WriteLine(d.Name);
                PrintDir(d, level + 1);
            }
        }
        public static void Tabs(int level)
        {
            for (int i = 0; i < level; i++)
            {
                Console.Write("    ");
            }
        }

        static void Main(string[] args)
        {
            // Создаем экземпляр dir для указанной папки
            DirectoryInfo dir = new DirectoryInfo("/Users/User/Desktop/PP2Labs");

            // Выводим содержимое папок с помощью рекурсивной функции
            PrintDir(dir, 0);
            
            // Ждем нажатия любой клавиши, чтобы показать результат выполнения
            Console.ReadKey();
        }
    }
}
