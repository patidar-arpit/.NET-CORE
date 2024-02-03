using EmployeeDAL.Models;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace EmployeeDAL.DAL
{
    public interface IEmployeeDal
    {
        List<Employee> GetAllEmployee();
        void AddEmployee(Employee emp);
        void UpdateEmployee(Employee emp);
        void DeleteEmployee(Employee emp);
    }

    public class EmployeeDal : IEmployeeDal
    {
        private readonly SqlConnection conn;
        
        public EmployeeDal()
        {
            conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeeDAL;Integrated Security=True;";
        }

        public void AddEmployee(Employee emp)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddEmployee";
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@City", emp.City);
                cmd.Parameters.AddWithValue("@Address", emp.Address);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw new Exception("Database Error!");
            }
        }

        public void DeleteEmployee(Employee emp)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAllEmployee()
        {
            List<Employee> list = new List<Employee>();
            try
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employee";
                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    Employee emp = new Employee() {Name = reader.GetString("Name"), City = reader.GetString("City"), Address = reader.GetString("Address")};
                    list.Add(emp);
                }

                reader.Close();
                conn.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Database Error!");
            }

        }

        public void UpdateEmployee(Employee emp)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateEmployee";
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@City", emp.City);
                cmd.Parameters.AddWithValue("@Address", emp.Address);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Database Error!");
            }
        }


    }
}
