using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PaylocityEmployeeBenefitsPackage.Data;
using PaylocityEmployeeBenefitsPackage.DataAccess.Repository.IRepository;
using PaylocityEmployeeBenefitsPackage.Models;

namespace PaylocityEmployeeBenefitsPackage.Controllers
{
    public class EmployeeController : Controller
    {

        public EmployeeController(IDataAccess dataAccess)
        {
            DataAccess = dataAccess;
        }

        public ApplicationDbContext DbContext { get; }
        public IDataAccess DataAccess { get; }

        public IActionResult Index()
        {
            var employees = DataAccess.EmployeeRepository.GetAll();
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
            DataAccess.EmployeeRepository.Add(employee);
            DataAccess.Save();
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
                DataAccess.EmployeeDependentRepository.Add(employeeDependent);
                DataAccess.Save();
                return RedirectToAction("Index");
            }
            return View(employeeDependent);
        }
    }
}
