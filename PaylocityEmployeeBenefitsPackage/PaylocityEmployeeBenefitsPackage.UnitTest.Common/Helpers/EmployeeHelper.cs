using PaylocityEmployeeBenefitsPackage.Models;

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
    }
}