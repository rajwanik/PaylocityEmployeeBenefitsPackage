using FluentAssertions;
using NUnit.Framework;
using PaylocityEmployeeBenefitsPackage.Business.Interfaces;
using PaylocityEmployeeBenefitsPackage.UnitTest.Common;

namespace PaylocityEmployeeBenefitsPackage.Business.UnitTest
{
    public class DeductionCalculatorTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(0,false,0,52000, 1961.54)]
        [TestCase(0, true, 0, 52000, 1965.38)]
        [TestCase(1,false,0, 52000, 1942.31)]
        [TestCase(1, true, 1, 52000, 1948.07)]
        [TestCase(2,false,0, 52000, 1923.08)]
        [TestCase(2, true, 0, 52000, 1926.92)]
        [TestCase(2, true, 1, 52000, 1928.84)]
        [TestCase(2, true, 2, 52000, 1930.76)]
        public void CalculateBenefitDeductionTest(int numberOfDependents,bool employeeNameStartsWithA, int numberOfDependentsNameStartingWithA, double salaryPerYear, double expectedBenefitAfterDeduction)
        {
            var employee = EmployeeHelper.CreateEmployee(numberOfDependents, employeeNameStartsWithA, numberOfDependentsNameStartingWithA, salaryPerYear);

            var deductionCalculator = new DeductionCalculator();

            var deductionAfterBenefitCost = deductionCalculator.CalculateBenefitDeduction(employee);

            deductionAfterBenefitCost.Should().Be(expectedBenefitAfterDeduction,"Expected beneift Cost does not match actual benefit cost.");
        }
    }
}