namespace DelegatesPractice
{
    public delegate void DelegateCar();
    public delegate void DelegateCar1(int a);
    //Car function using delegates
    internal class Program
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("Hello, World!");
            DelegateCar car1=new DelegateCar(Car);
            car1();


            
            DelegateCar1 car2=Car;
            car2(4);
        }

        static void Main2()
        {
            DelegateCar delegateCar = Car;
            Car();
            DelegateCar delegateBike = Bike;
            Bike();
        }
        static void Main3()
        {
            DelegateCar delegateCar = Car;
            

            delegateCar += Bike;
            

            delegateCar += Truck;

            delegateCar();

            delegateCar -= Bike;

            delegateCar();

           
        }




        public static void Car()
        {
            Console.WriteLine("Car Method");
        }
        public static void Bike()
        {
            Console.WriteLine("Bike Method");
        }

        public static void Truck()
        {
            Console.WriteLine("Truck Method");
        }


        public static  void Car(int a)
        {
            Console.WriteLine("Inside car(int) method");
        }
    }

}

namespace DelegatesPractice1
{

    internal class Program2
    {
        //creating delegates to call functions as parameters
        public delegate int DelegateMath(int x,int y);
        public static void Main(string[] args) 
        {

            Console.WriteLine("main");
            DelegateMath obj1 = Add;
            //Console.WriteLine(obj1(10, 5));

            //obj1 = Substract;
            //Console.WriteLine(obj1(10, 5));

            //LinkedList<int> list = new LinkedList<int>();
            Console.WriteLine(Calculation(Add, 5, 6));
            Console.WriteLine(Calculation(Substract, 5, 6));


        } 

        public static int Add(int x,int y)
        {
            return x + y;
        }

        public static int Substract(int x, int y)
        {
            return y-x;
        }

        public static int Calculation(DelegateMath obj1,int a, int b)
        {
            return obj1(a, b);
        }




    }

}