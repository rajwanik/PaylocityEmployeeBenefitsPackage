using FluentAssertions;
using NUnit.Framework;
using PaylocityEmployeeBenefitsPackage.UnitTest.Common;
using PaylocityEmployeeBenefitsPackage.UnitTest.Common.TestData;
using System.Collections.Generic;
using System.Linq;

namespace PaylocityEmployeeBenefitsPackage.Business.UnitTest
{
    public class DeductionCalculatorTest
    {
        private static EmployeeBenefitDeductionTestDataList[] _getEmployeeSalaryAfterDeductionTestData = new EmployeeBenefitDeductionTestDataList[]
        {
            new EmployeeBenefitDeductionTestDataList() 
            { 
                EmlpoyeeList =new List<EmployeeBenefitDeductionTestData>() {
                                                                            new EmployeeBenefitDeductionTestData(1,0,false,0,52000, 1961.54,38.46,0),
                                                                            new EmployeeBenefitDeductionTestData(2,0, true, 0, 52000, 1965.38,34.62,0),
                                                                            new EmployeeBenefitDeductionTestData(3,1,false,0, 52000, 1942.31,38.46,19.23),
                                                                            new EmployeeBenefitDeductionTestData(4,1, true, 1, 52000, 1948.07,34.62,17.31),
                                                                            new EmployeeBenefitDeductionTestData(5,2,false,0, 52000, 1923.08,38.46,38.46),
                                                                            new EmployeeBenefitDeductionTestData(6,2, true, 0, 52000, 1926.92,34.62,38.46),
                                                                            new EmployeeBenefitDeductionTestData(7,2, true, 1, 52000, 1928.84,34.62,36.54),
                                                                            new EmployeeBenefitDeductionTestData(8,2, true, 2, 52000, 1930.76,34.62,34.62)
                                                                           }
            } 
        };

        [Test]
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

        [Test]
        [TestCaseSource("_getEmployeeSalaryAfterDeductionTestData")]
        public void GetEmployeeSalaryAfterDeductionTest(EmployeeBenefitDeductionTestDataList testData)
        {
            var employeeList = EmployeeHelper.CreateEmployeeList(testData.EmlpoyeeList);

            var deductionCalculator = new DeductionCalculator();

            var actualEmployeeList = deductionCalculator.GetEmployeeSalaryAfterDeduction(employeeList);

            actualEmployeeList.Should().NotBeNullOrEmpty();
            actualEmployeeList.Should().HaveCount(testData.EmlpoyeeList.Count);
            foreach (var item in actualEmployeeList)
            {
                var expectedData = testData.EmlpoyeeList.FirstOrDefault(x => x.EmployeeId == item.ID);
                expectedData.Should().NotBeNull();
                item.EmployeeBenefitCostBeforeDeduction.Should().Be(expectedData.ExpectedEmployeeBenefitAfterDeduction, 
                    "Expected employee benefit after deduction does not match actual employee benefit after deduction.");
                item.SalaryAfterDeduction.Should().Be(expectedData.ExpectedBenefitAfterDeduction, 
                    "Expected salary after deduction does not match actual alary after deduction.");
                item.EmployeeDependentBenefitCostBeforeDeduction.Should().Be(expectedData.ExpectedEmployeeDependentBenefitAfterDeduction, 
                    "Expected employee dependent benefit after deduction does not match actual employee dependent benefit after deduction.");
            }


        }
    }
}