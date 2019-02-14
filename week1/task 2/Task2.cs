using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_2
{
    class Task2
    {
        static void Main(string[] args)
        {
            string name;
            string id;
            int yearOfStudy;

            public Student(string nameOfStudent, string currentId)
            {
                this.name = nameOfStudent;
                this.id = currentId;
                yearOfStudy = 0;

            }

            public void getInfo()
            {
                Console.WriteLine("Name: " + name);
                Console.WriteLine("Id: " + id);
            }

            public int increment()
            {
                yearOfStudy++;
                return yearOfStudy;
            }

        }

        class Task2
        {
            static void Main(string[] args)
            {
                Student s1 = new Student("Daniyar", "18BD");
                s1.getInfo();
                Console.WriteLine(s1.increment());
                Console.ReadKey();
            }
        }
    }
}
