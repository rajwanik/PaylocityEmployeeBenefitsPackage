using Microsoft.EntityFrameworkCore;
using PaylocityEmployeeBenefitsPackage.Data;
using PaylocityEmployeeBenefitsPackage.DataAccess.Repository.IRepository;
using PaylocityEmployeeBenefitsPackage.Models;
using System.Linq.Expressions;

namespace PaylocityEmployeeBenefitsPackage.DataAccess.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext applicationDbContext) :base(applicationDbContext)
        {

        }

        public void Update(Employee employee)
        {
            _applicationDbContext.Employee.Update(employee);
        }
    }
}
