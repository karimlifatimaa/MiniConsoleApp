using Core;
using Core.Exceptions;
using System.Xml.Linq;

namespace MiniConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit=false;
            string className;
            do
            {
                Console.WriteLine("Clasroom adini daxil edin ");
                className = Console.ReadLine();

            } while (!className.ClassNameCheck());


            ClassroomType type;
            do
            {
                Console.WriteLine("Enter the type");
                Console.WriteLine("(1: BackEnd, 2: FrontEnd): ");

            } while (!ClassroomType.TryParse(Console.ReadLine(),out type)||(int)type>2);
            Classroom classroom = new Classroom(className, type);

            bool flag =false;
            do
            {
                Console.WriteLine("1.Classroom yarat\r\n2.Student yarat\r\n3.Butun Telebeleri ekrana cixart\r\n4.Telebe sil\r\n5.Son ");
                Console.WriteLine("Secim edin:");
                string answer=Console.ReadLine();
                switch(answer)
                {

                    case "1":
                        flag = true;
                        break;
                    case "2":
                        if (flag != true)
                        {
                            Console.WriteLine("Sinif yaradilmayib");
                        }
                        else { 
                        Console.WriteLine("Name daxil et");
                        string name=Console.ReadLine();
                        Console.WriteLine("Surname daxil et");
                        string surname=Console.ReadLine();
                        Student student = new Student(name,surname);
                        classroom.StudentAdd(student);}
                        break;
                    case "3":                        
                        Student[] allStudents = classroom.GetAllStudent();
                        foreach (Student student in allStudents)
                        {
                            if (student != null)
                            {
                                Console.WriteLine(student);
                            }
                        }
                        break;
                    case "4":

                        int id;
                        do
                        {
                            Console.WriteLine("Silinecek telebenin Id-ni daxil edin: ");
                        } while (!int.TryParse(Console.ReadLine(), out id));
                        try
                        {
                            classroom.Delete(id);
                            Console.WriteLine("Telebe silindi.");
                        }
                        catch (StudentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "5": exit=true;
                        break;
                    default:
                        Console.WriteLine("Duzgun deyer daxil et");
                        break ; 
                }
            } while (!exit);
            
        }
    }
}
