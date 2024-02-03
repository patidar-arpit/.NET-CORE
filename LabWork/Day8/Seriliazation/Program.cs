using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;

namespace Seriliazation
{
    internal class Program
    {

        static List<Employee> lstEmp = new List<Employee>();
        public static void AddRecs()
        {


            lstEmp.Add(new Employee { EmpNo = 1, Name = "Arpit", Basic = 10000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 2, Name = "Vishal", Basic = 11000, DeptNo = 10, Gender = "M" });

            lstEmp.Add(new Employee { EmpNo = 3, Name = "Abhijit", Basic = 12000, DeptNo = 20, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 4, Name = "Mona", Basic = 11000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 5, Name = "Shweta", Basic = 12000, DeptNo = 20, Gender = "F" });

            lstEmp.Add(new Employee { EmpNo = 6, Name = "Sanjay", Basic = 11000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 7, Name = "Arpan", Basic = 10000, DeptNo = 30, Gender = "M" });

            lstEmp.Add(new Employee { EmpNo = 8, Name = "Shraddha", Basic = 11000, DeptNo = 40, Gender = "F" });
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            AddRecs();
           

            //BinarySer(lstEmp);
            //BinaryDer();

            SoapSer(lstEmp);
            SoapDer();

        }

        private static void SoapDer()
        {
            SoapFormatter sf = new SoapFormatter();
            Stream stream = new FileStream("D:\\test8.soap", FileMode.Open);

            List<Employee> emps = (List<Employee>)sf.Deserialize(stream);

            foreach (var emp in emps)
            {
                Console.WriteLine(emp.ToString());
            }
            stream.Close();


        }

        private static void SoapSer(List<Employee> lstEmp)
        {
            SoapFormatter sf = new SoapFormatter();
            Stream stream = new FileStream("D:\\test8.soap", FileMode.Create);

            sf.Serialize(stream, lstEmp);
           
            stream.Close();
            


        }

        private static void BinarySer(List<Employee> emps)
        {
            BinaryFormatter bf = new BinaryFormatter();
            Stream stream = new FileStream("D:\\test6.oat", FileMode.Create);

             #pragma warning disable SYSLIB0011
            bf.Serialize(stream, emps);
            #pragma warning restore SYSLIB0011
            stream.Close();

        }

        private static void BinaryDer()
        {
            BinaryFormatter bf = new BinaryFormatter();
            Stream stream = new FileStream("D:\\test6.oat", FileMode.Open);
            #pragma warning disable SYSLIB0011
            List<Employee> emps  =  (List<Employee>) bf.Deserialize(stream);
           #pragma warning restore SYSLIB0011

            foreach (var emp in emps)
            {
                Console.WriteLine(emp.ToString());
            }

        }



        [Serializable]
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
    }
}