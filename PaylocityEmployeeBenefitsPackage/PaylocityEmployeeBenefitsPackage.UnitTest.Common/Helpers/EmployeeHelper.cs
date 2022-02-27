using Microsoft.EntityFrameworkCore;
using PaylocityEmployeeBenefitsPackage.Data;
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

        public static ApplicationDbContext BuildApplicationDbContext(string dbName, int numberOfEmployees, bool includeDependents)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase(dbName + Guid.NewGuid().ToString());
            var applicationDbContext = new ApplicationDbContext(optionsBuilder.Options);
            //Add Test Data
            for (int i = 1; i <= numberOfEmployees; i++)
            {
                var employee = CreateNewEmployee(i, "Employee" + i.ToString());
                applicationDbContext.Add(employee);
                if (includeDependents)
                {
                    CreateNewDependentEmployee(employee,i,"EmployeeDependent" + i);
                }

            }
            applicationDbContext.SaveChanges();

            return applicationDbContext;
        }

        public static Employee CreateNewEmployee(int id, string name)
        {
            return new Employee() { ID = id, Name = name, CreatedDate = DateTime.Now, Salary = 52000 };
        }

        public static void CreateNewDependentEmployee(Employee employee, int id, string name)
        {
            var dependentEmployee = new EmployeeDependent();
            dependentEmployee.Name = name;
            dependentEmployee.Relationship = RelationshipType.Child;
            dependentEmployee.CreatedDate = DateTime.Now;
            dependentEmployee.EmployeeDependentIdentifier = id;
            if (employee.Dependents == null)
            {
                employee.Dependents = new List<EmployeeDependent>();
            }
            employee.Dependents.Add(dependentEmployee);
        }
    }
}