namespace PlacesToEat.Data.Common
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Contracts;
    using Models;

    public class DbUserRepository<T> : IDbUserRepository<T>
        where T : class, IAuditInfo, IDeletableEntity
    {
        public DbUserRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", nameof(context));
            }

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        private IDbSet<T> DbSet { get; }

        private DbContext Context { get; }

        public IQueryable<T> All()
        {
            return this.DbSet.AsQueryable().Where(x => !x.IsDeleted);
        }

        public IQueryable<T> AllWithDeleted()
        {
            return this.DbSet.AsQueryable();
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.UtcNow;
        }

        public T GetById(string id)
        {
            return this.DbSet.Find(id);
        }

        public void HardDelete(T entity)
        {
            this.DbSet.Remove(entity);
        }

        public void Save()
        {
            this.Context.SaveChanges();
        }
    }
}
