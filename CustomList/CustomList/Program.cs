using System.Threading.Channels;

namespace CustomList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomList<int> myList = new CustomList<int>();

          
            myList.Add(12);
            myList.Add(22);
            myList.Add(33);
            myList.Add(42);
            myList.Add(5);


            Console.WriteLine("Capasity"+ myList.Capacity) ;

            Console.WriteLine("Elementler:");
            myList.ForEach(x=>Console.WriteLine(x));

            int foundItem = myList.Find(x => x == 42);
            Console.WriteLine("Tapilan deyer: " + foundItem);

            int fountItem = myList.Find(x => x == 12);
            Console.WriteLine("Tapildi:" + fountItem);

            CustomList<int> evenNumbers = myList.FindAll(x => x % 2 == 0);
            Console.WriteLine("Cut ededler:");
            evenNumbers.ForEach(x => Console.WriteLine(x));

           
            Console.WriteLine(myList.Contains(2));
        }
    }
}
