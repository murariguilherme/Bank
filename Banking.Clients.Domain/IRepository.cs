using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Clients.Domain
{
    public interface IRepository<T> where T: Entity
    {
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> Search(Expression<Func<T, bool>> predicate);
        Task<int> SaveChanges();
    }
}
