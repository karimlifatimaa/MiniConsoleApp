using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Student
    {
        private static int _id;
        public int Id;
        public string Name { get; set; }
        public string Surname {  get; set; }
        public Student(string name,string surname)
        {
            Id=++_id;
            if (name.NameAndSurnameCheck())
            {
                Name = name;
            }
            else
            {
                Console.WriteLine("Invalid name format.");
            }
            if(surname.NameAndSurnameCheck()) 
            {
                Surname = surname;
            }
            else
            {
                Console.WriteLine("Invalid surname format.");
            }
        }
        public override string ToString()
        {
            return $"Id:{Id}, {Name} {Surname}";
        }
    }
}
