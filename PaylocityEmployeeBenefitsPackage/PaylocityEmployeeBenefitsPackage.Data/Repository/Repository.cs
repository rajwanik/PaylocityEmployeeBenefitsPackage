using Microsoft.EntityFrameworkCore;
using PaylocityEmployeeBenefitsPackage.Data;
using PaylocityEmployeeBenefitsPackage.DataAccess.Repository.IRepository;
using System.Linq.Expressions;

namespace PaylocityEmployeeBenefitsPackage.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _applicationDbContext;
        protected internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            this.dbSet = applicationDbContext.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, object>>? propertyFilter = null)
        {
            IQueryable<T> query = dbSet;
            if (propertyFilter != null)
            {
                return query.AsNoTracking()
                .Include(propertyFilter)
                .ToList();
            }
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, Expression<Func<T, object>>? propertyFilter = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            if (propertyFilter != null)
            {
                return query.AsNoTracking()
                .Include(propertyFilter)
                .FirstOrDefault();
            }

            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
