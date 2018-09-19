using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystemDB
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new TestingSystemModel())
            {
                IRepository<Test> testRepository = RepositoryFactory.Get<Test>();

                List<Test> testList = testRepository.FindBy(test => test.user_id == 3, ctx).ToList();

                var dict = new Dictionary<Test, int>(); 
                foreach(Test test in testList)
                {
                    if (test.questions.Count > 0)
                    {
                        dict.Add(test, test.questions.ElementAt(0).discipline_id);
                    }
                }

                var res = dict.GroupBy(x => x.Value).ToDictionary(x => x.Key, x => x.Count());

                var result = res.OrderByDescending(r => r.Value).First();
            }
        }
    }
}
