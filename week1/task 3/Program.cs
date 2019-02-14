using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string s = Console.ReadLine();
            string[] a = s.Split();
            List<string> list = new List<string>();
            foreach (string k in a)
            {
                list.Add(k);
                list.Add(k);

            }
            foreach (string k in list)
            {
                Console.Write(k + " ");
            }
            Console.ReadKey();
        }
    }
}
