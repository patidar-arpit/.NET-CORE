namespace StaticMembers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Class1.s_i = 2000;
            Console.WriteLine(Class1.s_i);
            Class1 class1 = new Class1();
            class1.I = 000;
            class1.NonStaticMethod();
            Class1.StaticMethod();

        }
    }

    class Class1
    {
        public static int s_i;
       
        private  int i;
         
       public int I { 
            get { return i; } 
            set 
            { 
                i = value;
                Console.WriteLine("Inside the setter");
            }
        }

        public Class1()
        {
            Console.WriteLine("Inside the Normal constructor");
            i = 10;
            s_i = 20;

        }
        
        static Class1()  // calls when teh class is get loaded
        {
            // i = 10; cannot access non static content  inside the static cheej
            s_i = 20;
            Console.WriteLine("Inside the static constructor"+" "+" "+s_i);
        }

        public int S_I
        {
            get { return s_i; }
            set { s_i = value;
                Console.WriteLine("Inside the set "+i+" "+s_i);
            }
        }

        public static void StaticMethod()
        {
            // i = 10;
            s_i = 100;
            Console.WriteLine("Inside the static method");
        }
        public void NonStaticMethod()
        {
            i = 200;
            s_i = 300;
            Console.WriteLine("Inside the non static method"+i+" "+s_i);
        }
        

    }

}
