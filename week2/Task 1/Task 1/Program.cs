using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("../../input.txt");
            String s = sr.ReadToEnd();
            Console.Write(s);
            char[] arr = s.ToCharArray(); 
            Array.Reverse(arr);
            String output = new string(arr);
            if (output == s)
            {
                Console.Write("YES");
            }
            else
                Console.Write("NO");
            sr.Close(); 
            Console.ReadKey();
        }
    }
}
