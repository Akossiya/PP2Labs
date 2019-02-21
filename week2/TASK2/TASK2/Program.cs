using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Task2
{
    class Program
    {
        public static bool isPrime(int k)
        {
            for (int i = 2; i <= Math.Sqrt(k); i++)
            {
                if (k % i == 0) return true;
            }
            return false;
        }

        static void Main(string[] args)

        {
            StreamReader sr = new StreamReader("../../input.txt");
            StreamWriter sw = new StreamWriter("../../output.txt");
            string s = sr.ReadToEnd();
            string[] arr = s.Split();
            foreach (string l in arr)
            {
                if (isPrime(int.Parse(l)) == false)
                {
                    sw.Write(l + " ");
                }
            }
            sr.Close();
            sw.Close();
            Console.ReadKey();

        }
    }
}
