namespace PaylocityEmployeeBenefitsPackage.DataAccess.Repository.IRepository
{
    public interface IDataAccess
    {
        IEmployeeRepository EmployeeRepository { get; }
        IEmployeeDependentRepository EmployeeDependentRepository { get; }
        void Save();
    }
}
