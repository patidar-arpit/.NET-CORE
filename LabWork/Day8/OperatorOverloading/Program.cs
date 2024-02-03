namespace OperatorOverloading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Employee emp1 = new Employee() { Id = 1,Name ="Arpit" };
            Employee emp2 = new Employee() { Id = 2, Name = "Jayesh" };
            Employee emp3 = new Employee();

            emp3 = emp1 + emp2;
            Console.WriteLine(emp3.Id+" "+emp3.Name);

        }
    }

    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static   Employee operator +(Employee a, Employee b)
        {
            return new Employee() { Id = a.Id + b.Id, Name = a.Name + b.Name };
        }

    }

}