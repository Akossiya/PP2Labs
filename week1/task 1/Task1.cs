using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Task1
    {
        public static bool IsItPrime(int k) // initializing the method to find prime number
        {

            for (int i = 2; i <= Math.Sqrt(k); i++) // loop to check if the particular number has divisors
            {
                if (k % i == 0)
                {
                    return true; // true for composite
                }
            }
            return false; // false for prime
        }


        static void Main(string[] args)
        {

            List<string> list = new List<string>(); // initializing dynamic array
            int n = int.Parse(Console.ReadLine());

            string[] arr = Console.ReadLine().Split(); // creating array from string 
            foreach (string z in arr) // using loop to check every string in array
            {
                if (IsItPrime(int.Parse(z)) == false) // using condition to check every string in array
                {
                    if (int.Parse(z) == 1) continue;
                    list.Add(z); // adding the element to the list
                }
            }
            Console.WriteLine(list.Count); // outputting the list size
            foreach (string a in list)
            {
                Console.Write(a + " "); //outputting the elements of the list
            }
            Console.ReadKey();
        }
    }
}



