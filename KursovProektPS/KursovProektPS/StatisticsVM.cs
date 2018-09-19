using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystemDB;

namespace KursovProektPS
{
    public class StatisticsVM : BaseVM
    {
        private StatisticsModel statistics;

        public StatisticsModel Statistics
        {
            get
            {
                return statistics;
            }

            set
            {
                statistics = value;
                RaisePropertyChanged("Statistics");
            }
        }

        public StatisticsVM()
        {
            statistics = new StatisticsModel();
            GetStatisticsForLoggedUser();
        }

        private void GetStatisticsForLoggedUser()
        {
            using (var ctx = new TestingSystemModel())
            {
                IRepository<Test> testRepository = RepositoryFactory.Get<Test>();
                IRepository<Discipline> disciplineRepository = RepositoryFactory.Get<Discipline>();
                IQueryable<Test> query = testRepository.FindBy(test => test.user_id == MainWindowVM.CurrentUser.id, ctx);

                Statistics.TestsCount = query.Count();
                List<Test> testList = query.ToList();

                var dict = new Dictionary<Test, int>();
                foreach (Test test in testList)
                {
                    if (test.questions.Count > 0)
                    {
                        dict.Add(test, test.questions.ElementAt(0).discipline_id);
                    }
                }

                var res = dict.GroupBy(x => x.Value).ToDictionary(x => x.Key, x => x.Count());
                var result = res.OrderByDescending(r => r.Value).First();

                Statistics.MostTestedDiscipline = disciplineRepository.FindById(result.Key).name;
            }
        }
    }
}
