using PaylocityEmployeeBenefitsPackage.Models;
using System.Linq.Expressions;

namespace PaylocityEmployeeBenefitsPackage.DataAccess.Repository.IRepository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        IEnumerable<Employee> GetAll(Expression<Func<Employee, object>> propertyFilter);
        void Update(Employee employee);
    }
}
