using Microsoft.EntityFrameworkCore;
using Banking.Clients.Domain;
using Banking.Clients.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Clients.Infra
{
    public abstract class Repository<T> : IRepository<T> where T: Entity, new()
    {
        private readonly ApplicationDbContext db;
        private readonly DbSet<T> dbSet; 

        public Repository(ApplicationDbContext context)
        {
            db = context;
            dbSet = this.db.Set<T>();
        }

        public async Task Create(T entity)
        {
            dbSet.Add(entity);
            await this.SaveChanges();
        }

        public async Task Delete(Guid id)
        {
            dbSet.Remove(new T { Id = id });
            await SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await dbSet.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<int> SaveChanges()
        {
            return await this.db.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> Search(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task Update(T entity)
        {
            dbSet.Update(entity);
            await this.db.SaveChangesAsync();
        }
    }
}
