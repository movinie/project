using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using MoviesCatalog.Model;

namespace MoviesCatalog.Data.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class
    {
        private CatalogEntities dataContext;
        private readonly IDbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected CatalogEntities DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
            dataContext.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
            dataContext.SaveChanges();
        }

        public virtual void Update(int id, T entity)
        {
            var item = dbSet.Find(id);
            if (item != null)
            {
                dataContext.Entry(item).CurrentValues.SetValues(entity);
                dataContext.SaveChanges();
            }
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbSet.Remove(obj);
            dataContext.SaveChanges();
        }

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual int Count()
        {
            return dbSet.Count();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault<T>();
        }
    }
}
