namespace ExtensionMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            int i = 100;
            i.display();   // internally compiler will call below line for this.
           // MyExtension.display(i);  

            Console.WriteLine(i.Add(10));  //MyExtension.Add(i ,10);

            Manager manager = new Manager() { Id = 1,Name ="Arpit",Perks="Stocks" };

            manager.display();   // MyExtension.dispay(manager);
        }
    }

    static class MyExtension
    {
       public  static void display(this int i)
        {
            Console.WriteLine(i);
        }

        public static int Add(this int a ,int b)
        {
            return a + b; 
        }
        public static void display(this Employee emp)
        {
            Console.WriteLine(emp.Name);
            Console.WriteLine(emp.Id);
            //Console.WriteLine(emp.Perks);

        }

    }

    class Employee
    {
       public  int Id {  get; set; }
       public string Name { get; set; }

        
    }

    class Manager:Employee
    {
       public string Perks { get; set; }

    }
}
