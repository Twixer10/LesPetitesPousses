using LPP.DAL.Contracts.Repositories;
using LPP.Entities;
using Microsoft.EntityFrameworkCore;

namespace LPP.DAL.Repositories
{
    public class BaseRepository<TEntity> : IHybridBaseRepository<TEntity> where TEntity : EntityBase
    {
        protected readonly LppDbContext Context;

        public BaseRepository(LppDbContext context)
        {
            Context = context;
        }

        public virtual TEntity? GetById(Guid id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().AsEnumerable();
        }

        public virtual TEntity Add(TEntity entity)
        {
            var tracked = Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
            return tracked.Entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            var tracked = Context.Set<TEntity>().Update(entity);
            Context.SaveChanges();
            return tracked.Entity;
        }

        public virtual void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            Context.SaveChanges();
        }

        public virtual void DeleteById(Guid id)
        {
            var entity = GetById(id);

            if (entity is null) return;

            Delete(entity);
        }

        public virtual bool Exists(Guid id)
        {
            return Context.Set<TEntity>().Any(e => e.Id == id);
        }

        public virtual int Count()
        {
            return Context.Set<TEntity>().Count();
        }

        public virtual async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            var tracked = await Context.Set<TEntity>().AddAsync(entity);
            await Context.SaveChangesAsync();
            return tracked.Entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var tracked = Context.Set<TEntity>().Update(entity);
            await Context.SaveChangesAsync();
            return tracked.Entity;
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task DeleteByIdAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);

            if (entity is null) return;

            await DeleteAsync(entity);
        }

        public virtual async Task<bool> ExistsAsync(Guid id)
        {
            return await Context.Set<TEntity>().AnyAsync(e => e.Id == id);
        }

        public virtual async Task<int> CountAsync()
        {
            return await Context.Set<TEntity>().CountAsync();
        }
    }
}