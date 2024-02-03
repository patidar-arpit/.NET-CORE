namespace Constructor2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            DerivedClass dc = new DerivedClass();
        }
    }
    class BaseClass
    {
        private int i;

        public BaseClass()
        {
            Console.WriteLine("Inside the Constructor of the Base  Class :Parameter less Constructor");
            i = 10;
        }

        public BaseClass(int i)
        {
            Console.WriteLine("Inside the Constructor of the Base Class :Parameterized  Constructor");
            this.i = i;
        }
    }

    class DerivedClass : BaseClass
    {
        int j;
        public DerivedClass()
        {
            Console.WriteLine("Inside the Constructor of the Derived Class :Parameter less Constructor");
            j = 10;
        }

        public DerivedClass(int j, int i) : base(i)
        {
            Console.WriteLine("Inside the Constructor of the Derived Class :Parameterized Constructor");
            this.j = j;
        }
    }
}

