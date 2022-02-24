using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaylocityEmployeeBenefitsPackage.DataAccess.Repository.IRepository
{
    public interface IDataAccess
    {
        IEmployeeRepository EmployeeRepository { get; }
        IEmployeeDependentRepository EmployeeDependentRepository { get; }
        void Save();
    }
}
