using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PaylocityEmployeeBenefitsPackage.Business.Interfaces;
using PaylocityEmployeeBenefitsPackage.Controllers;
using PaylocityEmployeeBenefitsPackage.DataAccess.Repository.IRepository;
using PaylocityEmployeeBenefitsPackage.Models;
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

            var result = employeeController.Index();

            result.Should().NotBeNull();
            result.Should().BeOfType<ViewResult>();
            ((ViewResult)result).ViewName.Should().BeNull();
        }
    }
}