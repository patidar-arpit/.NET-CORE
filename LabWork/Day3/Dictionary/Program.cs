using System.Collections.ObjectModel;

namespace Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Dictionary<int,string> fictObj = new Dictionary<int,string>();

            fictObj.Add(7, "arpit");
            fictObj.Add(2, "bittu");
            fictObj.Add(3, "aayush");
            fictObj.Add(4, "ALISHA");

            fictObj.Remove(2);
            Console.WriteLine(fictObj.Count);
            Console.WriteLine(fictObj.ContainsKey(7));
            Console.WriteLine(fictObj.ContainsValue("arpit"));
          //  Console.WriteLine(fictObj.Contains("1"));
            foreach (KeyValuePair<int,string> kvp in fictObj)
            {

                Console.WriteLine(kvp.Key);
                Console.WriteLine(kvp.Value);

            }

        }
    }
}