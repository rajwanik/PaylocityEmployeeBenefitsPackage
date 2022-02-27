using FluentAssertions;
using NUnit.Framework;
using PaylocityEmployeeBenefitsPackage.DataAccess.Repository;
using PaylocityEmployeeBenefitsPackage.Models;
using PaylocityEmployeeBenefitsPackage.UnitTest.Common;

namespace PaylocityEmployeeBenefitsPackage.DataAccess.UnitTest
{
    public class RepositoryTest
    {   
        [Test]
        public void AddTest()
        {
            var applicationDbContext = EmployeeHelper.BuildApplicationDbContext(nameof(RepositoryTest.AddTest),3,false);

            var repository = new Repository<Employee>(applicationDbContext);

            repository.Add(EmployeeHelper.CreateNewEmployee(4,"Kailash"));
            applicationDbContext.SaveChanges();

            applicationDbContext.Employee.FirstOrDefault(x=>x.ID == 4).Should().NotBeNull();

        }

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public void GetAllTest(bool includeDependents)
        {
            var applicationDbContext = EmployeeHelper.BuildApplicationDbContext(nameof(RepositoryTest.GetAllTest),5, includeDependents);

            var repository = new Repository<Employee>(applicationDbContext);

            IEnumerable<Employee> result;

            if (includeDependents)
            {
                result = repository.GetAll(x => x.Dependents);
            }
            else
            {
                result = repository.GetAll();
            }

            result.Should().NotBeNull("Employees returned is null.");
            result.Count().Should().Be(5,"Expected and actual number of employees does not match.");
            
           foreach (var employee in result)
           {
                if (includeDependents)
                {
                    employee.Dependents.Should().NotBeNull($"Employee dependents for employee id {employee.ID} was null.");
                    employee.Dependents.Count().Should().Be(1, $"Number of expected and actual employee dependents for employee id {employee.ID} did not match.");
                }
                else
                {
                    employee.Dependents.Should().BeNull($"Employee dependents for employee id {employee.ID} was not null.");
                }
            }

        }

        [Test]
        [TestCase(2,false,true)]
        [TestCase(3, false,true)]
        [TestCase(6, false,false)]
        [TestCase(4,true,true)]
        public void GetFirstOrDefaultTest(int idToFind,bool includeDependents, bool isIdPresent)
        {
            var applicationDbContext = EmployeeHelper.BuildApplicationDbContext(nameof(RepositoryTest.GetFirstOrDefaultTest), 5, includeDependents);

            var repository = new Repository<Employee>(applicationDbContext);

            Employee result;

            if (includeDependents)
            {
                result = repository.GetFirstOrDefault(x=>x.ID == idToFind,x => x.Dependents);
            }
            else
            {
                result = repository.GetFirstOrDefault(x => x.ID == idToFind);
            }

            if (!isIdPresent)
            {
                result.Should().BeNull("Employee should be null.");
                return;
            }

            result.Should().NotBeNull("Employee returned is null.");
            result.ID.Should().Be(idToFind, "Expected and actual employee ID does not match.");

            if (includeDependents)
            {
            result.Dependents.Should().NotBeNull($"Employee dependents for employee id {result.ID} was null.");
            result.Dependents.Count().Should().Be(1, $"Number of expected and actual employee dependents for employee id {result.ID} did not match.");
            }
            else
            {
            result.Dependents.Should().BeNull($"Employee dependents for employee id {result.ID} was not null.");
            }

        }


    }
}