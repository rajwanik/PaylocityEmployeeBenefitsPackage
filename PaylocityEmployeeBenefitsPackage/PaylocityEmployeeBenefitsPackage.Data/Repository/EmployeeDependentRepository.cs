using PaylocityEmployeeBenefitsPackage.Data;
using PaylocityEmployeeBenefitsPackage.DataAccess.Repository.IRepository;
using PaylocityEmployeeBenefitsPackage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityEmployeeBenefitsPackage.DataAccess.Repository
{
    public class EmployeeDependentRepository : Repository<EmployeeDependent>, IEmployeeDependentRepository
    {
        public EmployeeDependentRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
