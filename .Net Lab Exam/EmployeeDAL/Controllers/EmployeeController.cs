using EmployeeDAL.Models;
using EmployeeDAL.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDAL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;
        public EmployeeController()
        {
            _employeeService = new EmployeeService();
        }

        // GET: EmployeeController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowAll()
        {

            return View(_employeeService.GetAllEmployee().ToList());
        }



        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee empObj)
        {
            try
            {
                _employeeService.AddEmployee(empObj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        //public ActionResult Edit(string Name, string City, string Address)
        //{
        //    return View();
        //}
        public ActionResult Edit(Employee obj)
        {
            return View(obj);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee obj,int id)
        {
            try
            {
                
                Employee emp = _employeeService.GetAllEmployee().Find(o => o.Name==obj.Name);
                _employeeService.GetAllEmployee();
                _employeeService.UpdateEmployee(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
