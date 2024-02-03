namespace InnerFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


            display();

        }

        public static void display()

        {

            int a = 100;

             void inner(){
                Console.WriteLine(a);
                int a = 200;
                a = 300;
                Console.WriteLine(a);  // 300
            }

            inner();

            Console.WriteLine(a); // 100


        }
    }
}