using FluentAssertions;
using NUnit.Framework;
using PaylocityEmployeeBenefitsPackage.UnitTest.Common;
using PaylocityEmployeeBenefitsPackage.Utility;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PaylocityEmployeeBenefitsPackage.Models.UnitTest
{
    public class EmployeeDependentTest
    {
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void EmployeeDependentModelValidationTest(bool isModelValid)
        {
            var employeeDependent = new EmployeeDependent();

            if (isModelValid)
            {
                var employee = new Employee();
                EmployeeHelper.CreateNewDependentEmployee(employee, 1, "Test");
                employeeDependent = employee.Dependents.FirstOrDefault();
            }

            var results = new List<ValidationResult>();

            var context = new ValidationContext(employeeDependent);
            Validator.TryValidateObject(employeeDependent, context, results, true);

            if (isModelValid)
            {
                results.Count().Should().Be(0);
            }
            else
            {
                results.Count().Should().Be(1);
                var nameRequiredErrorMessage = string.Format(Constants.FieldIsRequiredErrorMessage, nameof(EmployeeDependent.Name));
                results.FirstOrDefault(x => x.ErrorMessage == nameRequiredErrorMessage).Should().
                    NotBeNull($"Error message - {nameRequiredErrorMessage}, not found.");
            }
        }
    }
}
