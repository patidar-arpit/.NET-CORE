using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeesMVC.Models;

namespace EmployeesMVC.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly LabExamContext _context;

        public EmployeesController(LabExamContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: Employees
        public async Task<IActionResult> ViewEmployees()
        {
              return _context.Employees != null ? 
                          View(await _context.Employees.ToListAsync()) :
                          Problem("Entity set 'LabExamContext.Employees'  is null.");
        }

      
        // GET: Employees/Create
        public IActionResult AddEmployee()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEmployee([Bind("Id,Name,City,Dob,Gender,Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                await Console.Out.WriteLineAsync("EmpID is:"+employee.Id);
                _context.Add(employee);
                await _context.SaveChangesAsync();
                ViewBag.Message = "Employeed Added With EmpID:";
                ViewBag.EmployeeId = employee.Id;
                return View();
            }

            return View(employee);
        }

        private bool EmployeeExists(int id)
        {
          return (_context.Employees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
