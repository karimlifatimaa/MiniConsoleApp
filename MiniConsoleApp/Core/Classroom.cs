using Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Classroom
    {
        private static int _id;
        public int Id;
        public string Name {  get; set; }
        
        public Student[] students = new Student[] { };
        public ClassroomType Type;
        public Classroom(string name, ClassroomType type)
        {
            Id = ++_id;
            Type = type;
            
            if (Type == ClassroomType.BackEnd)
            {
                students = new Student[20];
                Console.WriteLine("Limit 20dir");
            }
            else
            {
                students = new Student[15];
                Console.WriteLine("Limit 15dir");
            }
            if (name.ClassNameCheck())
            {
                Name = name;
            }
            else
            {
                Console.WriteLine("Invalid classroom name format.");
            }

        }
        public void StudentAdd(Student student)
        {
            Array.Resize(ref students, students.Length + 1);
            students[students.Length - 1] = student;
        }
        public Student FindId(int id)
        {
            foreach (Student student in students)
            {
                if (student.Id == id)
                {
                    return student;
                }
            }
            throw new StudentException();
        }
        public void Delete(int id)
        {
            bool studentFound = false;
            Student[] filtered = new Student[] { };
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i] != null && students[i].Id != id)
                {
                    Array.Resize(ref filtered, filtered.Length + 1);
                    filtered[filtered.Length - 1] = students[i];
                }
                else
                {
                    studentFound = true;
                }
            }
            if (!studentFound)
            {
                throw new StudentException();
            }
            students = filtered;
        }

        public Student[] GetAllStudent()
        {
            return students;
        }
    }
}
