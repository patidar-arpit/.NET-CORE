namespace Comparer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Employee[] emps = new Employee[4];
            //string name = "", short deptNo = 0, decimal Basic = 1000
            emps[0] = new Employee("Arpit",9,10000);
            emps[1] = new Employee("Alisha", 1, 20000);
            emps[2] = new Employee("varun", 4, 30000);
            emps[3] = new Employee("Armaan", 3, 40000);

             Array.Sort(emps);
            ///   Array.Sort<Employee>(emps); // same as above

            foreach (Employee emp in emps)
            {
                Console.WriteLine(emp.toString());
            }

        }
    }

    public class Employee:IComparable<Employee>
    {

        private string Name;
        private static int empNoCounter = 0;
        private int EmpNo;


        public decimal Basic { get; set; }
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
                if (value < 0)
                    Console.WriteLine("Invalid entry");
                else
                    DeptNo = value;
            }
            get
            {
                return DeptNo;
            }
        }
        public Employee(string name = "", short deptNo = 0, decimal Basic = 1000)
        {
            PropertyName = name;
            PropertyOfDeptNo = deptNo;
            EmpNo = empNoCounter++;
            this.Basic = Basic;
        }

        public int CompareTo(Employee? other)
        {
            if (this.PropertyOfDeptNo > other.PropertyOfDeptNo)
                return 1;
            else if (this.PropertyOfDeptNo < other.PropertyOfDeptNo)
                return -1;
            return 0;
           
        }

        public string toString()
        {
            return "NAME = "+this.Name + "id = " + this.EmpNo;
        }
    }
}

    
