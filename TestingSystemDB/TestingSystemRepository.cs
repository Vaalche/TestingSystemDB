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
        public void Add(T entity, DbContext ctx)
        {
                ctx.Set<T>().Add(entity);
                ctx.SaveChanges();

        }

        public void Delete(T entity)
        {
            using (var ctx = new C())
            {
                ctx.Set<T>().Remove(entity);
            }
        }

        public IQueryable<T> FindBy(Expression<Func<T,bool>> predicate, DbContext ctx)
        {
                return ctx.Set<T>().Where(predicate);
        }

        public T FindById(int id)
        {
            using (var ctx = new C())
            {
                return ctx.Set<T>().Find(id);
            }
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
