using System;          
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK4
{
    class Program
    {
        static void Main(string[] args)
        {
            string rootPath = "/Users/User/Desktop/PP2Labs/week2/TASK4/";
            string sourFile = rootPath + "dir1/file.dat";
            string destFile = rootPath + "dir2/file.dat";
            try
            {
                FileStream fs = File.Create(sourFile);
                fs.Dispose();
                
                File.Copy(sourFile, destFile, true);
                File.Delete(sourFile);
                Console.WriteLine("Программа выполнена успешно!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.ReadKey();
        }
    }
}
