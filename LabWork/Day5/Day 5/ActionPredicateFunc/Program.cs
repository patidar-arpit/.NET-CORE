namespace ActionPredicateFunc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Action o1 = Display;  // we use the action for the function which have the return type void;
            o1();
            Action<string> o2 = Display;
            o2("Hello");



            Func<int, int> o3 = GetDouble; /// use the Func which fucction  have any return type
            Console.WriteLine(o3(10));

            Func<int, int, int> o4 = Add;
            Console.WriteLine(o4(10,5));

            Predicate<int> o5 = isEven; /// use predicate with the function ehich have the return type as only the bool
            Console.WriteLine(o5(4));

            //Predicate<int> o6 = GetDouble;    // 
            //Console.WriteLine(o6(10));

        }

        public static void Display()
        {
            Console.WriteLine("Inside the display function");
        }
        public static void Display(string s)
        {
            Console.WriteLine("Inside the display function"+s);
        }

        public static  int GetDouble(int a)
        {
            return a * 2;
        }

        public static int Add(int a,int b)
        {
            return a + b;
        }

        public static bool isEven(int a)
        {
            return a%2 == 0;
        }


    }
}