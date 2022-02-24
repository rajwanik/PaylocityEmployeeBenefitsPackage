using PaylocityEmployeeBenefitsPackage.Data;
using PaylocityEmployeeBenefitsPackage.DataAccess.Repository.IRepository;
using PaylocityEmployeeBenefitsPackage.Models;

namespace PaylocityEmployeeBenefitsPackage.DataAccess.Repository
{
    public class EmployeeDependentRepository : Repository<EmployeeDependent>, IEmployeeDependentRepository
    {
        public EmployeeDependentRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
