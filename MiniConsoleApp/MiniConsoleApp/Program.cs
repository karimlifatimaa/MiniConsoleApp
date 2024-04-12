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
                Console.WriteLine("Clasroom adini daxil edin:");
                className = Console.ReadLine();

            } while (!className.ClassNameCheck());


            ClassroomType type;
            do
            {
                Console.WriteLine("Type daxil et:");
                Console.WriteLine("1: BackEnd\r\n2: FrontEnd ");

            } while (!ClassroomType.TryParse(Console.ReadLine(),out type)||(int)type>2);
            Classroom classroom = new Classroom(className, type);

            bool flag =false;
            do
            {
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("1.Classroom yarat\r\n2.Student yarat\r\n3.Butun Telebeleri ekrana cixart\r\n4.Telebe sil\r\n5.Secilmis id telebeni ekrana cixart\r\n6.Son ");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Secim edin:");
                string answer=Console.ReadLine();
                switch(answer)
                {

                    case "1":
                        flag = true;
                        Console.WriteLine("Sinif yaradildi");
                        break;
                    case "2":
                        if (flag != true)
                        {
                            Console.WriteLine("Sinif yaradilmayib");
                        }
                        else {                           
                            string name;
                            do
                            {
                                Console.WriteLine("Name daxil edin ");
                                name = Console.ReadLine();

                            } while (!name.NameAndSurnameCheck());
                            string surname;
                            do
                            {
                                Console.WriteLine("Surname daxil edin ");
                                surname = Console.ReadLine();

                            } while (!surname.NameAndSurnameCheck());

                            Student student = new Student(name,surname);
                        classroom.StudentAdd(student);}
                        break;
                    case "3":                        
                        Student[] allStudents = classroom.GetAllStudent();
                        foreach (Student student in allStudents)
                        {
                            if (student != null)
                            {
                                Console.WriteLine("---------------------------------");
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
                    case "5":
                        int idF;
                        do
                        {
                            Console.WriteLine("Axtardiginiz telebenin Id-ni daxil edin: ");
                        } while (!int.TryParse(Console.ReadLine(), out idF));
                        try
                        {
                            Console.WriteLine(classroom.FindId(idF));
                            Console.WriteLine("Telebe Tapildi.");
                        }
                        catch (StudentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "6": exit=true;
                        break;
                    default:
                        Console.WriteLine("Duzgun deyer daxil et");
                        break ; 
                }
            } while (!exit);
            
        }
    }
}
