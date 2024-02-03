namespace INHERITANCE_ASS_DAY3
{
    internal class Program
    {
        static void Main(string[] args)
        {
             Console.WriteLine("Hello, World!");

            //string name = "", decimal basic = 0, short deptNo = 0
            Employee employee = new Manager("Alisha", 234444, 1,"Manager");
            Employee employee2 = new CEO("Arpit",2345, 1);
            Employee employee3 = new GeneralManager("Alisha", 234444, 1, "General-Manager", "Stocks");


            Console.WriteLine(employee.CalcNetSalary());
            Console.WriteLine(employee2.CalcNetSalary());
            //Console.WriteLine(employee2.CalcNetSalary());
             Console.WriteLine(employee3.CalcNetSalary());
        }
    }
    public abstract  class Employee
    {

        private string Name;
        private static int empNoCounter = 0;
        private int EmpNo;

        public  decimal basic;
        public  abstract decimal Basic { get; set; }
        private short DeptNo;

        //the Property name is just a wrapper to wrap the data members defined
        //so we simply return that wrapped value while setting and getting.
        public string PropertyName
        {
            set
            {
                if (value == null)
                {
                    Console.WriteLine("Invalid input,retry again!!");
                }
                else
                {
                    Name = value;
                }

            }
            get
            {
                return Name;
            }

        }

        public int PropertyOfEmpNo
        {
            get
            {
                return EmpNo;
            }
        }

       

        public short PropertyOfDeptNo
        {
            set
            {
                if (value > 0)
                    Console.WriteLine("Invalid entry");
                else
                    DeptNo = value;
            }
            get
            {
                return DeptNo;
            }
        }
        public Employee(string name = "", short deptNo = 0)
        {
            PropertyName = name;
            PropertyOfDeptNo = deptNo;
            EmpNo = empNoCounter++;

        }


        public abstract decimal CalcNetSalary();
        public void display()
        {
            Console.WriteLine(PropertyOfEmpNo + " " + "Name: " + this.Name + "Basic Pay: "+ "Department No: " + DeptNo);
        }




    }

    public class Manager : Employee
    {
        public string designation;

        public override decimal Basic
        {
            get { return basic; }
            set { basic = value; }

        }

        public  string Designation
        {
            get { return designation; }
            set
            {
                if(value == null)
                {
                    Console.WriteLine("Designation cannot be null");
                }
                else
                {
                    designation = value;
                }
            }
        }

       

        public Manager(string name = "", decimal basic = 0, short deptNo = 0,string designation=""):base(name,deptNo) 
        {
            Designation = designation;
            Basic = basic;
        }

        public override decimal CalcNetSalary()
        {
            return Basic + 2000;

        }
    }

    public class GeneralManager : Manager 
    {

      

        public string Perks { get; set; }
     
        public override decimal Basic
        {
            get { return basic; }
            set { basic = value; }

        }

        public GeneralManager(string name = "", decimal basic = 0, short deptNo = 0, string designation = "", string perks="") : base(name, basic, deptNo, designation)
        {
            Perks = perks;

        }

        public override decimal CalcNetSalary()
        {
            return Basic + 3000;

        }

    }

    public class CEO : Employee
    {

        public CEO(string name = "", decimal basic = 0, short deptNo = 0):base(name, deptNo)
        {
            Basic = basic;
        }
        public override decimal Basic
        {
            get { return basic; }
            set { basic = value; }

        }
        public sealed override decimal CalcNetSalary()
        {
            return Basic + 10000;
        }
    }
}