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
            var applicationDbContext = EmployeeHelper.BuildApplicationDbContext(nameof(RepositoryTest.AddTest),3);

            var repository = new Repository<Employee>(applicationDbContext);

            repository.Add(EmployeeHelper.CreateNewEmployee(4,"Kailash"));
            applicationDbContext.SaveChanges();

            applicationDbContext.Employee.FirstOrDefault(x=>x.ID == 4).Should().NotBeNull();

        }

        [Test]
        public void GetAllTest()
        {
            var applicationDbContext = EmployeeHelper.BuildApplicationDbContext(nameof(RepositoryTest.GetAllTest),5);

            var repository = new Repository<Employee>(applicationDbContext);

            var result = repository.GetAll();
            result.Count().Should().Be(5);

        }

    }
}