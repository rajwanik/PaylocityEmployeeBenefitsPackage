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

        public IEnumerable<Employee> GetAll(Expression<Func<Employee, object>> propertyFilter)
        {
            IQueryable<Employee> query = dbSet;
            return query.AsNoTracking().Include(propertyFilter).ToList();
        }

        public void Update(Employee employee)
        {
            _applicationDbContext.Employee.Update(employee);
        }
    }
}
