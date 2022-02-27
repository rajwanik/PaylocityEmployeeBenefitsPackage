using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PaylocityEmployeeBenefitsPackage.Business.Interfaces;
using PaylocityEmployeeBenefitsPackage.Controllers;
using PaylocityEmployeeBenefitsPackage.DataAccess.Repository.IRepository;
using PaylocityEmployeeBenefitsPackage.Models;
using PaylocityEmployeeBenefitsPackage.Utility;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PaylocityEmployeeBenefitsPackage.Conrollers.UnitTest
{
    public class EmployeeControllerTest
    {
        [Test]
        public void IndexTest()
        {
            var dataAccess = new Mock<IDataAccess>();
            var deductionCalculator = new Mock<IDeductionCalculator>();
            var employeeRepository = new Mock<IEmployeeRepository>();

            dataAccess.Setup(x=>x.EmployeeRepository).Returns(employeeRepository.Object);

            Expression<Func<Employee, object>>? expression = e => e.Dependents;
             var employeeList = new List<Employee>();
            employeeRepository.Setup(x => x.GetAll(It.Is<Expression<Func<Employee, object>>?>(x=>x.Equals(expression)))).Returns(employeeList);
            deductionCalculator.Setup(x => x.GetEmployeeSalaryAfterDeduction(It.Is<List<Employee>>(x => x.Equals(employeeList)))).Returns(employeeList);

            var employeeController = new EmployeeController(dataAccess.Object,deductionCalculator.Object);

            var result = employeeController.Index() as ViewResult;

            result.Should().NotBeNull();
            result.ViewName.Should().BeNull();
        }

        [Test]
        public void CreateTest()
        {
            var dataAccess = new Mock<IDataAccess>();
            var deductionCalculator = new Mock<IDeductionCalculator>();

            var employeeController = new EmployeeController(dataAccess.Object, deductionCalculator.Object);

            var result = employeeController.Create() as ViewResult;

            result.Should().NotBeNull();
            result.ViewName.Should().BeNull();
        }

        [Test]
        public void CreateEmployeePostTest()
        {
            var dataAccess = new Mock<IDataAccess>();
            var deductionCalculator = new Mock<IDeductionCalculator>();
            var employeeRepository = new Mock<IEmployeeRepository>();
            var employee = new Employee();

            dataAccess.Setup(x => x.EmployeeRepository).Returns(employeeRepository.Object);
            employeeRepository.Setup(x => x.Add(It.Is<Employee>(x => x.Equals(employee))));
            dataAccess.Setup(x => x.Save());

            var employeeController = new EmployeeController(dataAccess.Object, deductionCalculator.Object);

            var result = employeeController.Create(employee) as RedirectToActionResult;

            result.Should().NotBeNull();
            result.ActionName.Should().Be(nameof(EmployeeController.Index));
        }

        [Test]
        public void AddDependentTest()
        {
            var dataAccess = new Mock<IDataAccess>();
            var deductionCalculator = new Mock<IDeductionCalculator>();
            int employeeId = 2;

            var employeeController = new EmployeeController(dataAccess.Object, deductionCalculator.Object);

            var result = employeeController.AddDependent(employeeId) as ViewResult;

            
            result.Should().NotBeNull();
            result.ViewName.Should().BeNull();
            result.ViewData.Should().ContainKey(Constants.EmployeIDViewDataKey, 
                $" {Constants.EmployeIDViewDataKey} Key not found in view data");
            result.ViewData[Constants.EmployeIDViewDataKey].Should().Be(employeeId);
        }

        [Test]
        public void AddEmployeeDependentPostTest()
        {
            var dataAccess = new Mock<IDataAccess>();
            var deductionCalculator = new Mock<IDeductionCalculator>();
            var employeeDependentRepository = new Mock<IEmployeeDependentRepository>();

            var employeeController = new EmployeeController(dataAccess.Object, deductionCalculator.Object);

            var employeeDependent = new EmployeeDependent();
            dataAccess.Setup(x=>x.EmployeeDependentRepository).Returns(employeeDependentRepository.Object);
            employeeDependentRepository.Setup(x => x.Add(It.Is<EmployeeDependent>(x => x.Equals(employeeDependent))));
            dataAccess.Setup(x => x.Save());

            var result = employeeController.AddDependent(employeeDependent) as RedirectToActionResult;


            result.Should().NotBeNull();
            result.ActionName.Should().Be(nameof(EmployeeController.Index));
        }

        [Test]
        public void ViewEmployeeDependentTest()
        {
            var dataAccess = new Mock<IDataAccess>();
            var deductionCalculator = new Mock<IDeductionCalculator>();
            var employeeRepository = new Mock<IEmployeeRepository>();

            var employeeController = new EmployeeController(dataAccess.Object, deductionCalculator.Object);

            var employeeID = 2;
            Expression<Func<Employee, object>>? expression = e => e.Dependents;
            Func<Employee, bool> func = e => e.ID == employeeID;
            dataAccess.Setup(x => x.EmployeeRepository).Returns(employeeRepository.Object);
            employeeRepository.Setup(x => x.GetFirstOrDefault(It.Is<Expression<Func<Employee, bool>>>(x => x.Equals(func)), 
                    It.Is<Expression<Func<Employee, object>>?>(x => x.Equals(expression))));

            var result = employeeController.ViewDependent(employeeID) as ViewResult;


            result.Should().NotBeNull();
            result.ViewName.Should().BeNull();
        }
    }
}