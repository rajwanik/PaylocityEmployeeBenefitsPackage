using Microsoft.EntityFrameworkCore;
using PaylocityEmployeeBenefitsPackage.Data;
using PaylocityEmployeeBenefitsPackage.DataAccess.Repository.IRepository;
using PaylocityEmployeeBenefitsPackage.Models;

namespace PaylocityEmployeeBenefitsPackage.DataAccess.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext applicationDbContext) :base(applicationDbContext)
        {

        }

        public IEnumerable<Employee> GetAll(bool includeAllProperties = false)
        {
            IQueryable<Employee> query = dbSet;
            query.Include(x => x.Dependents);
            return query.ToList();
        }

        public void Update(Employee employee)
        {
            _applicationDbContext.Employee.Update(employee);
        }
    }
}
