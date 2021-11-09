using Entities.Interfaces;
using Repository.EFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EFCore.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly RepositoryContext context;

        public Repository(RepositoryContext context)
        {
            this.context = context;
        }

        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetById(object id)
        {
            return context.Set<T>().Find(id);
        }

        public IQueryable<T> Query()
        {
            return context.Set<T>();
        }

        public void Remove(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }
    }
}
