using System;
using System.Linq;
using System.Linq.Expressions;

namespace TestingSystemDB
{
    interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T FindById(int id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
    }
}