using PaylocityEmployeeBenefitsPackage.Models;
using PaylocityEmployeeBenefitsPackage.UnitTest.Common.TestData;

namespace PaylocityEmployeeBenefitsPackage.UnitTest.Common
{
    public class EmployeeHelper
    {
        public static Employee CreateEmployee(int numberOfDependents, bool employeeNameStartsWithA, int numberOfDependentsNameStartingWithA, double salaryPerYear)
        {
            Employee employee = new Employee();

            if (employeeNameStartsWithA)
            {
                employee.Name = "Amy";
            }
            else
            {
                employee.Name = "Kyle";
            }

            employee.Salary = salaryPerYear;
            if (numberOfDependents > 0)
            {
                employee.Dependents = new List<EmployeeDependent>();
            }

            for(int i=0;i<numberOfDependents;i++)
            {
                var employeeDependent = new EmployeeDependent();
                
                if (numberOfDependentsNameStartingWithA > 0)
                {
                    employeeDependent.Name = "ATest";
                    numberOfDependentsNameStartingWithA--;
                }
                else
                {
                    employeeDependent.Name = "Mary";
                }

                employeeDependent.Relationship = RelationshipType.Child;

                employee.Dependents.Add(employeeDependent);
            }

            return employee;
        }

        public static List<Employee> CreateEmployeeList(List<EmployeeBenefitDeductionTestData> employeeTestData)
        {
            var employeeList = new List<Employee>();

            foreach (var testData in employeeTestData)
            {
                var employee = CreateEmployee(testData.NumberOfDependents, testData.EmployeeNameStartsWithA, testData.NumberOfDependentsNameStartingWithA, testData.SalaryPerYear);

                employee.ID = testData.EmployeeId;
                employeeList.Add(employee);
            }

            return employeeList;
        }
    }
}