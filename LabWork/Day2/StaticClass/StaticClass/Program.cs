namespace StaticClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            
            //ExampleClass.a = 10;
            //ExampleClass.StaticMethod();

            

        }
    }

    static class ExampleClass
    {

        public static int a;
        public static void StaticMethod()
        {
            Console.WriteLine("Insode the static methdod "+ a);
        }


    }
    class NonStaticInnerClass
    {
        public int a;
        public static int b;

        public class InnerClass
        {
            public int x;
            public void InnerClassNonStaticMethdod()
            {
                Console.WriteLine("Inside the InnerClassNonStaticMethdod");
            }
            public static void InnerClassStaticMethdod()
            {
                Console.WriteLine("Inside the InnerClassStaticMethdod");
            }
        }
    }
    class StaticInnerClass
    {
        public int x;
        static class A 
        {
            public static  int i1=10;

            public static void StaticMethod()
            {
                Console.WriteLine("Inside the static method;");
            }

        }
        public void NonStaticMethod()
        {
            Console.WriteLine("Insode the non static method..!!!");
        }

    }

    

}
