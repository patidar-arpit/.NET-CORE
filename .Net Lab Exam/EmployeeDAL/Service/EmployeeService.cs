
using EmployeeDAL.Models;
using EmployeeDAL.DAL;

namespace EmployeeDAL.Service
{

    public interface IEmployeeService
    {
        List<Employee> GetAllEmployee();
        void AddEmployee(Employee emp);
        void UpdateEmployee(Employee emp);
        void DeleteEmployee(Employee emp);
    }

    public class EmployeeService : IEmployeeService
    {
        public readonly IEmployeeDal employeeDAL;

        public EmployeeService()
        {
            employeeDAL = new EmployeeDal();
        }

        public void AddEmployee(Employee emp)
        {
            employeeDAL.AddEmployee(emp);
        }

        public void DeleteEmployee(Employee emp)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAllEmployee()
        {
            return employeeDAL.GetAllEmployee();
        }

        public void UpdateEmployee(Employee emp)
        {
            employeeDAL.UpdateEmployee(emp);
        }
    }
}
