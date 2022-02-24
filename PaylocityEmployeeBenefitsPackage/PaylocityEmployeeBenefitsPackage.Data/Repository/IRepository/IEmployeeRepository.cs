using PaylocityEmployeeBenefitsPackage.Models;

namespace PaylocityEmployeeBenefitsPackage.DataAccess.Repository.IRepository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        IEnumerable<Employee> GetAll(bool includeAllProperties = false);
        void Update(Employee employee);
    }
}
