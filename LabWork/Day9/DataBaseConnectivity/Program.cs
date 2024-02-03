
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataBaseConnectivity
{
    internal class Program
    {
        static void Main0(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //Connect();
            // InsertDepartment();      //trying the code of  method and then commentting it out line by line
            // InsertEmployee();        // done

            // InsertEmployee1(new Employee() { EmpNo = 2, Name="Bittu",Basic = 100000,DeptNo = 2});

            // inserting with parameter
            // InsertEmployee2(new Employee() { EmpNo = 3, Name = "Jayesh", Basic = 30000, DeptNo = 1 });

            //with procedure insert
            // InsertEmployee3(new Employee() { EmpNo = 4, Name = "Kapil", Basic = 40000, DeptNo = 4 });

            //  UpdateEmployee(5);

            DeleteEmployee(4); // deleted employee wit id =5;

        }

        private static void DeleteEmployee(int EmpId)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=ActsDec2023;Integrated Security=True;";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteEmployee";
                cmd.Parameters.AddWithValue("@EmpId", EmpId);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Employee Deleted");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally { conn.Close(); }
        }

        private static void UpdateEmployee(int EmpId)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=ActsDec2023;Integrated Security=True;";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateEmployee";
                cmd.Parameters.AddWithValue("@EmpId", EmpId);
                // i want to update the name of kapil as kapil kumar so pass this as parameter to the update procedure 
                cmd.Parameters.AddWithValue("@Name", "Kapil Kumar");
                cmd.ExecuteNonQuery();
                Console.WriteLine("Employee Updated");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally { conn.Close(); }   

        }

        private static void InsertEmployee3(Employee emp)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True;";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertEmployee";

                cmd.Parameters.AddWithValue("@EmpNo", emp.EmpNo);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Basic", emp.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", emp.DeptNo);

                cmd.ExecuteNonQuery();
                Console.WriteLine("Success");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally { conn.Close(); }

        }

        private static void InsertEmployee2(Employee emp)
        {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True;";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DepartMentNo)";

                cmd.Parameters.AddWithValue("@EmpNo",emp.EmpNo);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Basic", emp.Basic);
                cmd.Parameters.AddWithValue("@DepartMentNo",emp.DeptNo);

                cmd.ExecuteNonQuery();
                Console.WriteLine("Success");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally { conn.Close(); }   

        }

        private static void InsertDepartment()
        {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True;";
            try
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conn;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = "insert into Departments values(2,'IT')";
                sqlCommand.ExecuteNonQuery(); // execute the query and return that how many rows ared get affected;
                Console.WriteLine("Department INserted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally { conn.Close(); }

        }

        private static void InsertEmployee()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True;";
            try
            {
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conn;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = "insert into Employees(EmpNo,Name,Basic,DeptNo) values(1,'Arpit',60000,1)";
                sqlCommand.ExecuteNonQuery(); // execute the query and return that how many rows ared get affected;
                Console.WriteLine("Employee INserted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally { conn.Close(); }
            
        }

        private static void InsertEmployee1(Employee emp)
        {
         
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True;";

            try
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conn;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = $"insert into Employees values({emp.EmpNo},'{emp.Name}',{emp.Basic},{emp.DeptNo})";
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Success..!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { conn.Close(); }
        }



        private static void Connect()
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                //"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

                conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True;";
                conn.Open();
                Console.WriteLine("Connection Successfully");
            }

            catch (Exception ex)
            {
                Console.WriteLine("Connection Denied");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
                
            }

        }


        public class Employee
        {
            public int EmpNo { get; set; }
            public string Name { get; set; }
            public decimal Basic { get; set; }
            public int DeptNo { get; set; }


        }
    }
}


namespace RetrieveData
{
    internal class Program1
    {
        public static void Main()
        {
            // ReadSingleValue(1); // Display the Name of the Employee whose id is 1 // it will only  give single value 

           // DataReader1();

            Employee emp = GetSingleEmployee(1); // give the employee  with the EmpNo =2;
            Console.WriteLine(emp.ToString());


            List<Employee> emps = GetAllEmployees();
            foreach(Employee item  in emps)
            {
                Console.WriteLine(item.ToString());

            }

        }

        private static List<Employee> GetAllEmployees()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=ActsDec2023;Integrated Security=True;";
            List<Employee> emps = new List<Employee>();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employees";
               

                SqlDataReader dr = cmd.ExecuteReader();

                //iterate  through the table record one by one 
                while (dr.Read()) // 
                {
                    emps.Add(new Employee(dr.GetInt32(0), dr.GetString(1), dr.GetDecimal(2), dr.GetInt32(3)));
                   
                }

                return emps;



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return emps;
            }
            finally { conn.Close(); }



        }
        private static Employee GetSingleEmployee(int EmpNo)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=ActsDec2023;Integrated Security=True;";
            Employee emp = new Employee();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employees where EmpNo = @EmpNo";
                cmd.Parameters.AddWithValue("@EmpNo", EmpNo);

                SqlDataReader dr = cmd.ExecuteReader();

               // if no employee found with that empid dr.Read give false
                if (dr.Read()) // 
                {
                   
                    emp.EmpNo = dr.GetInt32(0);
                    emp.Name = dr.GetString(1);
                    emp.Basic = dr.GetDecimal(2);
                    emp.DeptNo = dr.GetInt32(3);
                }

                return emp;



            }
            catch (Exception ex)
            {
                    Console.WriteLine(ex.Message);
                   return emp;
            }
            finally { conn.Close(); }   


        }

        private static void DataReader1()
        {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=ActsDec2023;Integrated Security=True;";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employees ";
               
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Console.WriteLine(dr[0]+" " + dr[1]);
                        
                }
              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
            finally { conn.Close(); }


        }
        private static void ReadSingleValue(int EmpNo)
        {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=ActsDec2023;Integrated Security=True;";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select Name from Employees where EmpNo =@EmpNo ";
                cmd.Parameters.AddWithValue("@EmpNo", EmpNo);
                //cmd.CommandText = "select * from Employees";
                object  name = cmd.ExecuteScalar(); // it will return the first column  of first row int the result (returned by the query)
                Console.WriteLine(name);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
               
            }
            finally { conn.Close(); }

        }
    }
    public class Employee
    {
        public Employee() { }
        public Employee(int v1, string v2, decimal v3, int v4)
        {
            EmpNo = v1;
            Name = v2;
            Basic = v3; 
            DeptNo = v4;
        }

        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }

        override
        public String ToString()
        {
            return EmpNo + "," + Name + "," + Basic + "," + DeptNo;
        }
        
    }

}



