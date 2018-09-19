using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace TestingSystemDB
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity, DbContext ctx);
        void Update(T entity);
        void Delete(T entity);
        T FindById(int id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, DbContext ctx);
    }
}