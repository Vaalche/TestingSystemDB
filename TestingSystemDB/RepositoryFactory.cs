using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystemDB
{
    public static class RepositoryFactory
    {
        public static IRepository<T> Get<T>() where T : class
        {
            Type type = typeof(T);
            if (typeof(User).Equals(type))
            {
                return (IRepository<T>)new UserRepository();
            }
            else if (typeof(Discipline).Equals(type))
            {
                return (IRepository<T>)new DisciplineRepository();
            }
            else if(typeof(Question).Equals(type))
            {
                return (IRepository<T>)new QuestionRepository();
            }
            else if(typeof(Test).Equals(type))
            {
                return (IRepository<T>)new TestRepository();
            }
            else return null;
        }
    }
}
