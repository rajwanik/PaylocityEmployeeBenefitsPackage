using PaylocityEmployeeBenefitsPackage.Data;
using PaylocityEmployeeBenefitsPackage.DataAccess.Repository.IRepository;

namespace PaylocityEmployeeBenefitsPackage.DataAccess.Repository
{
    public class DataAccess : IDataAccess
    {
        public DataAccess(ApplicationDbContext applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
            EmployeeRepository = new EmployeeRepository(applicationDbContext);
            EmployeeDependentRepository = new EmployeeDependentRepository(applicationDbContext);
        }
        public IEmployeeRepository EmployeeRepository {get; private set;}


        public IEmployeeDependentRepository EmployeeDependentRepository { get; private set; }
        public ApplicationDbContext ApplicationDbContext { get; }

        public void Save()
        {
            ApplicationDbContext.SaveChanges();
        }
    }
}
