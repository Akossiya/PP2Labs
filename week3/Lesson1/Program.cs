using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task4
{
    class FarManager
    {
        static void Main(string[] args)
        {
             public int cursor;
        public string path;
        public FarManager() { }
        public FarManager(string path)
        {
            this.path = path;
            cursor = 0;
        }
        public void show()
        {
            DirectoryInfo dir = new DirectoryInfo(this.path);
            FileSystemInfo[] fs = dir.GetFileSystemInfos();
            for (int i = 0; i < fs.Length; i++)
            {
                Console.WriteLine(fs[i]);
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            string path = "/Users/Daniyar/Desktop/PP2";
            FarManager farManager = new FarManager(path);
            farManager.show();
            Console.ReadKey();
        }
    }
}
