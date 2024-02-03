using Microsoft.Data.SqlClient;
using System.Data;

namespace Transactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("Hello, World!");

            ExampleTransaction();

        }

        private static void ExampleTransaction()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=ActsDec2023;Integrated Security=True;";

            try
            {
                conn.Open();

                SqlTransaction t = conn.BeginTransaction();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Transaction = t;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Employees values(10,'aaaaaa',300000,1)";
                

                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = conn;
                cmd1.Transaction = t;

                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "insert into Employees values(10,'aaaaaa',300000,1)";

                try
                {
                    cmd.ExecuteNonQuery();

                    cmd1.ExecuteNonQuery();

                    t.Commit();
                    Console.WriteLine("Comittedddd");
                }
                catch (Exception ex)
                {
                    t.Rollback();
                    Console.WriteLine("Roll Backed.>!!");
                }


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