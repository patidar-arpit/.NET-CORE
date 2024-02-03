namespace Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //Example1 exp = new Example1();
            //exp.insert();
            //exp.update();

            A a1 = new Example1();
            a1.delete();
            B b1 = new Example1();
            b1.delete();


        }
    }

    interface A
    {
        void insert();

        void update();

        void delete();

    }

    interface B
    {
        void delete();


    }

    class Example1 : A, B
    {


        public void insert()
        {
            Console.WriteLine("A.insert() Inside the insert");
        }

        public void update()
        {
            Console.WriteLine("A.update() Inside the update");
        }

        void B.delete()  // Specifying that it is the delete() method of B class I am overrinding
        {
            Console.WriteLine("B.delete() Inside the delete");
        }

        void A.delete()
        {
            Console.WriteLine("A.delete() Inside the delete");
        }
    }
}
