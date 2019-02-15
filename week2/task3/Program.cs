using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!File.Exists(@"/Users/Daniyar/Desktop/pp2/Week2/task4/input.txt"))
            {
                FileStream fs = File.Create(@"/Users/Daniyar/Desktop/pp2/Week2/task4/input.txt");
                fs.Close();
            }

            string sourcePath = @"/Users/Daniyar/Desktop/pp2/Week2/task4";
            string targetPath = @"/Users/Daniyar/Desktop/pp2/Week2/task4/subdir";

            string sourceFile = System.IO.Path.Combine(sourcePath, "input.txt");
            string destFile = System.IO.Path.Combine(targetPath, "input.txt");

            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }
            try
            {
                File.Copy(sourceFile, destFile, true);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            try
            {
                File.Delete(@"/Users/Daniyar/Desktop/pp2/Week2/task4/input.txt");
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }
    }
}
