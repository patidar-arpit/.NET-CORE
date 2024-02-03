using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace State_Management.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            ViewData["a"] = 10;
            ViewData["b"] = 20;
            TempData["c"] = 30; 
             //return View();  // if we write this all three are avialabe to the view 

           return RedirectToAction("Index1");// ONLY C IS AVAILABLE IN VIEW A AND B ARE NOT AVIALBALE BECAUSE IN REDIRECT VIEWDATA IS NOT AVAILABE

        }
        public IActionResult Index1()
        {

            return View(); 

        }

        public IActionResult Session1() 
        {
            TempData["x"] = 10;
            HttpContext.Session.SetInt32("a", 10);
            HttpContext.Session.SetString("b", "Hello");

            Employee emp = new Employee() { EmpNo = 1 ,Name = "Arpit"};
            string jsonEmp =JsonSerializer.Serialize<Employee>(emp);

            HttpContext.Session.SetString("emp", jsonEmp);
            return View();

        }

        public IActionResult Session2()
        {
            return View();    // Now the variable stored int the req1 that is ../Session1 is now avialable int he view of the Session2 
                             // beacuse the scope is session and they will available in any request not only in thier particular req
        }




    }

    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
    }
}
