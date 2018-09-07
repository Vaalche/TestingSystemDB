using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystemDB
{
    public abstract class TestingSystemRepository<C, T> : IRepository<T> where T : class where C : DbContext, new()
    {
        private C context = new C();

        public C Context
        {
            get
            {
                return context;
            }

            set
            {
                context = value;
            }
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindBy(Expression<Func<T,bool>> predicate)
        {
            return Context.Set<T>().Where(predicate); 
        }

        public T FindById(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
