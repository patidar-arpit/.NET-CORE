namespace PartialMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            A a = new A();
            a.displaay();
        }
    }

     partial  class A
    {
          public  partial void displaay();  // if this func is get called from main its code will be reatined its implementation is in diff partial class
    }                                         // if no one call this the function the code will be removed from the compiler

    partial class A
    {

        public  partial void displaay()
        {
            Console.WriteLine("Inside the displaay func");
        }
    }


}
