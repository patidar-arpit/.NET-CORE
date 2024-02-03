

using System.Diagnostics;

namespace LinkExamples
{
    internal class Program
    {
        static List<Employee> lstEmp = new List<Employee>();
        static List<Department> lstDept = new List<Department>();
        public static void AddRecs()
        {
            lstDept.Add(new Department { DeptNo = 10, DeptName = "SALES" });
            lstDept.Add(new Department { DeptNo = 20, DeptName = "MKTG" });
            lstDept.Add(new Department { DeptNo = 30, DeptName = "IT" });
            lstDept.Add(new Department { DeptNo = 40, DeptName = "HR" });

            lstEmp.Add(new Employee { EmpNo = 1, Name = "Vikram", Basic = 10000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 2, Name = "Vishal", Basic = 11000, DeptNo = 10, Gender = "M" });

            lstEmp.Add(new Employee { EmpNo = 3, Name = "Abhijit", Basic = 12000, DeptNo = 20, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 4, Name = "Mona", Basic = 11000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 5, Name = "Shweta", Basic = 12000, DeptNo = 20, Gender = "F" });

            lstEmp.Add(new Employee { EmpNo = 6, Name = "Sanjay", Basic = 11000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 7, Name = "Arpan", Basic = 10000, DeptNo = 30, Gender = "M" });

            lstEmp.Add(new Employee { EmpNo = 8, Name = "Shraddha", Basic = 11000, DeptNo = 40, Gender = "F" });
        }
        static void Main1(string[] args)
        {
            Console.WriteLine("Hello, World!");
            AddRecs();
            IEnumerable<Employee> emps0 = from emp in lstEmp select emp;
            //var emps = from emp in lstEmp select emp;
            foreach (Employee emp in emps0) 
            {
                 Console.WriteLine(emp.ToString());
            }

            var emps1 = from emp in lstEmp select new { emp.Name, emp.DeptNo };
            foreach (var emp in emps1)
            {
                Console.WriteLine(emp.Name+" "+emp.DeptNo+" ");
               
            }

        }

        static void Main2()
        {
          
            AddRecs();
            var emps = from emp in lstEmp
                       where emp.Basic > 10000  && emp.EmpNo >5 
                       select emp;
              
            foreach (var emp in emps) 
            {
                 Console.WriteLine(emp);
            }
 
        }

        static void Main3()
        {

            AddRecs();
            var emps = from emp in lstEmp
                       where emp.EmpNo > 2
                       orderby emp.EmpNo descending 
                       select emp ;

            foreach (var emp in emps)
            {
                Console.WriteLine(emp);
            }

        }

        static void Main4()
        {

            AddRecs();
            var emps = from emp in lstEmp
                       join dept in lstDept
                       on emp.DeptNo equals dept.DeptNo
                       select new { emp, dept };

            foreach (var obj in emps)
            {
                Console.WriteLine(obj.emp.Name +" "+obj.dept.DeptName+" ");
            }

        }

    }
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }
        public string Gender { get; set; }
        public override string ToString()
        {
            string s = Name + "," + EmpNo.ToString() + "," + Basic.ToString() + "," + DeptNo.ToString();
            return s;
        }
    }

    public class Department
    {
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
    }

}

namespace LinkExamples2
{

    internal class Program
    {
        static List<Employee> lstEmp = new List<Employee>();
        static List<Employee> lstEmp1 = new List<Employee>();

        static List<Department> lstDept = new List<Department>();
        public static void AddRecs()
        {
            lstDept.Add(new Department { DeptNo = 10, DeptName = "SALES" });
            lstDept.Add(new Department { DeptNo = 20, DeptName = "MKTG" });
            lstDept.Add(new Department { DeptNo = 30, DeptName = "IT" });
            lstDept.Add(new Department { DeptNo = 40, DeptName = "HR" });

            lstEmp.Add(new Employee { EmpNo = 1, Name = "Vikram", Basic = 10000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 2, Name = "Vishal", Basic = 11000, DeptNo = 10, Gender = "M" });

            lstEmp.Add(new Employee { EmpNo = 3, Name = "Abhijit", Basic = 12000, DeptNo = 20, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 4, Name = "Mona", Basic = 11000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 5, Name = "Shweta", Basic = 12000, DeptNo = 20, Gender = "F" });

            lstEmp.Add(new Employee { EmpNo = 6, Name = "Sanjay", Basic = 11000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 7, Name = "Arpan", Basic = 10000, DeptNo = 30, Gender = "M" });

            lstEmp.Add(new Employee { EmpNo = 8, Name = "Shraddha", Basic = 11000, DeptNo = 40, Gender = "F" });
        }

        static Employee GetEmps(Employee emp)
        {
            return emp;
        }

        public static void Main1()
        {
            AddRecs();
           // var emps = lstEmp.Select(GetEmps); // one method in select 
            var emps = lstEmp.Select((emp) =>emp);
            
            foreach (var emp in emps)
            {
                Console.WriteLine(emp);
            }
            var emps1 = lstEmp.Select((emp) =>emp.Name);

            foreach( var emp in emps1)
            {
                Console.WriteLine(emp);
            }

            var emps2 = lstEmp.Select((emp) => new { emp.EmpNo,emp.Name });

            foreach (var item in emps2)
            {
                Console.WriteLine(item.EmpNo+" "+item.Name);
            }

            



        }

        public static void Main2()
        {

            AddRecs();
            //var emps = lstEmp.Where(emp => emp.Basic > 10000); //this also works it will filter and auto select that whole emp obj
            var emps = lstEmp.Where(emp => emp.Basic>10000).Select(emp => new {emp.EmpNo,emp.Name,emp.Basic});
            foreach(var item in emps)
            {
                Console.WriteLine(item);
            }
        }

        public static void Main3()
        {
            AddRecs();
             var emps = lstEmp.OrderBy(obj => obj.Name);  //Acsending order by Name; 
           // var emps = lstEmp.OrderByDescending(emp => emp.EmpNo); // descending order by EmpNo;
            //var emps = lstEmp.OrderBy(emp => emp.DeptNo).ThenBy(emp=>emp.Name); // order by aesc empNo and if emp same it will do sorting by emp name in aesc orrde
            foreach(var item in emps)
            {
                Console.WriteLine(item);
            }
        }

        public static void Main4()
        {
            AddRecs();
            //join method for joing two tables accept four parameters
            var emps = lstEmp.Join(lstDept, emp => emp.DeptNo, dept => dept.DeptNo, (emp, dept) => new { emp, dept });

            foreach (var item in emps)
            {
                Console.WriteLine(item.emp.Name+" "+item.emp.DeptNo);
            }

        }

        public static void Main5()
        {
            AddRecs();
            Employee emp = lstEmp.Single(e => e.EmpNo == 1); //one record = okay return that record 
            //Employee emp = lstEmp.Single(e => e.EmpNo == 10);  //no records = error
            //Employee emp = lstEmp.Single(e => e.Basic > 5000); //multiple records - error


            Employee emp1 = lstEmp.SingleOrDefault(e => e.EmpNo == 1); //one record = okay
            //Employee emp = lstEmp.SingleOrDefault(e => e.EmpNo == 10); //no records=null
            //Employee emp = lstEmp.SingleOrDefault(e =>  e.Basic > 5000);//multiple records - error

            if (emp != null)
                Console.WriteLine(emp.Name + "," + emp.EmpNo);
            else
                Console.WriteLine("not found");
            Console.ReadLine();
        }


        public static void Main()
        {
            //Plinq example;
            AddRecs2();
            Stopwatch st = new Stopwatch(); 

            st.Start();

            // var emps = lstEmp1.Select(emp => new { Name = longRunningFunction(emp.Name), emp.EmpNo }); // take to much time
            var emps = lstEmp1.AsParallel().AsOrdered().Select(emp => new { Name = longRunningFunction(emp.Name), emp.EmpNo }); // will take less time beacuese multiple thread are running to solve the query link

            foreach(var item in emps)
            {

                Console.WriteLine(item.Name+" "+item.EmpNo);
            }

        }

        public static string longRunningFunction(string name)
        {
            Thread.Sleep(1000); 
            return name.ToUpper();
        }

        public static void AddRecs2()
        {
            for (int i = 0; i < 200; i++)
            {
                lstEmp1.Add(new Employee { EmpNo = i + 1, Name = "Vikram" + i, Basic = 10000, DeptNo = 10, Gender = "M" });
            }
        }

    }

    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }
        public string Gender { get; set; }
        public override string ToString()
        {
            string s = Name + "," + EmpNo.ToString() + "," + Basic.ToString() + "," + DeptNo.ToString();
            return s;
        }
    }
    public class Department
    {
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
    }

}
