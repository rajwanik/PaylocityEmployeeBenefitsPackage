using System.Linq.Expressions;

namespace PaylocityEmployeeBenefitsPackage.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T: class
    {
        T GetFirstOrDefault(Expression<Func<T,bool>> filter, Expression<Func<T, object>>? propertyFilter = null);
        IEnumerable<T> GetAll(Expression<Func<T, object>>? propertyFilter = null);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);


    }
}
