using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UserProduct.DAL.Entity;

namespace UserProduct.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DbContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        public Repository(DbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public async Task<List<T>> Get()
        {
            if (typeof(T) == typeof(BaseContentEntity))
                return await entities.Where(x => !(x as BaseContentEntity).IsDeleted).ToListAsync();
            else
                return await entities.ToListAsync();
        }
        public async Task<List<T>> Get(Expression<Func<T, bool>> predicate)
        {
            return await entities.Where(predicate).ToListAsync();
        }
        public async Task<T> GetById(int id)
        {
            return await entities.SingleOrDefaultAsync(s => s.Id == id);
        }
        public async Task Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            entities.Add(entity);
            await context.SaveChangesAsync();
        }
        public async Task Update(T entity)
        {
            if (entity == default) throw new ArgumentNullException("entity");
            
            context.Attach(entity);

            if (entity is BaseContentEntity)
            {
                (entity as BaseContentEntity).UpdateDate = DateTime.Now;
                (entity as BaseContentEntity).IsDeleted = true;
            }

            await context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            if (id == default) throw new ArgumentNullException("entity");

            T entity = await entities.SingleOrDefaultAsync(s => s.Id == id);
            if (entity is BaseContentEntity)
            {
                (entity as BaseContentEntity).UpdateDate = DateTime.Now;
                (entity as BaseContentEntity).IsDeleted = true;
            }
            else
                entities.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteRange(Expression<Func<T, bool>> predicate)
        {
            if (predicate == default) throw new ArgumentNullException("entity");

            var records = entities.Where(predicate);
            if (typeof(T) == typeof(BaseContentEntity))
            {
                foreach (var record in records)
                {
                    (record as BaseContentEntity).UpdateDate = DateTime.Now;
                    (record as BaseContentEntity).IsDeleted = true;
                }
            }
            else
                entities.RemoveRange(records);
            await context.SaveChangesAsync();
        }

    }
}
