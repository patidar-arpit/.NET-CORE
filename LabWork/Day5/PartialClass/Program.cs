namespace PartialClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            A a1 = new A();
            Console.WriteLine(a1.a);
            Console.WriteLine(a1.b);
            Console.WriteLine(a1.c);
            Console.WriteLine(a1.d);


        }
    }

    partial class A
    {
        public int a=10;
        public int b=20;


    }

    partial class A
    {
        public int c=30;
        public int d=40;
    }
}
