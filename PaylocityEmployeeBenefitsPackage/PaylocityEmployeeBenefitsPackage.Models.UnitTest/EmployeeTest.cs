using FluentAssertions;
using NUnit.Framework;
using PaylocityEmployeeBenefitsPackage.UnitTest.Common;
using PaylocityEmployeeBenefitsPackage.Utility;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PaylocityEmployeeBenefitsPackage.Models.UnitTest
{
    public class EmployeeTest
    {
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void EmployeeModelValidationTest(bool isModelValid)
        {
            var employee = new Employee();

            if (isModelValid)
            {
                employee = EmployeeHelper.CreateNewEmployee(1, "Test");
            }

            var results = new List<ValidationResult>();

            var context = new ValidationContext(employee);
            Validator.TryValidateObject(employee, context, results,true);

            if (isModelValid)
            {
                results.Count().Should().Be(0);
            }
            else
            {
                results.Count().Should().Be(1);
                var nameRequiredErrorMessage = string.Format(Constants.FieldIsRequiredErrorMessage, nameof(Employee.Name));
                results.FirstOrDefault(x=>x.ErrorMessage == nameRequiredErrorMessage).Should().
                    NotBeNull($"Error message - {nameRequiredErrorMessage}, not found.");
            }
        }
    }
}