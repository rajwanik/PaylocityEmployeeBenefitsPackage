using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PaylocityEmployeeBenefitsPackage.Data;
using PaylocityEmployeeBenefitsPackage.Models;

namespace PaylocityEmployeeBenefitsPackage.Controllers
{
    public class EmployeeController : Controller
    {
        public EmployeeController(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public ApplicationDbContext DbContext { get; }

        public IActionResult Index()
        {
            var employees = DbContext.Employee.ToList();
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            employee.CreatedDate = DateTime.Now;
            DbContext.Employee.Add(employee);
            DbContext.SaveChanges();
            return RedirectToAction("Index");
        }

      

        public IActionResult AddDependent(int id)
        {
          ViewData["EmployeeID"] = id;
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddDependent(EmployeeDependent employeeDependent)
        {
            if (ModelState.IsValid)
            {
                employeeDependent.CreatedDate = DateTime.Now;
                DbContext.EmployeeDependent.Add(employeeDependent);
                DbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeDependent);
        }
    }
}
