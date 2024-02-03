using System.Security.Cryptography;

namespace Collection_SortedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            SortedList<int,string> sl = new SortedList<int,string>();

            sl.Add(5, "Arpit");
            sl.Add(2, "Hello");
            sl.Add(3, "Alisha");
            sl.Add(4, "Annna");

            sl[2] = "hii";

            foreach(KeyValuePair<int ,string> item in sl)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value);
            }

            sl.Remove(2);
            Console.WriteLine(sl.Count);
            sl.RemoveAt(1);
            Console.WriteLine(sl.ContainsValue("hELOOO"));
            Console.WriteLine(sl.ContainsKey(5));
            
        }
    }
}