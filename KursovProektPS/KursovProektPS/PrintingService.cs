using System.IO;
using System.Linq;
using TestingSystemDB;

namespace KursovProektPS
{
    class PrintingService : IPrintingService
    {
        private string fileName;

        public PrintingService(string fileName)
        {
            this.fileName = fileName;
        }

        public void PrintTest(int id)
        {
            Test test = null;
            IRepository<Test> testRepository = RepositoryFactory.Get<Test>();
            using (var ctx = new TestingSystemModel())
            {
                test = ctx.Tests.Find(id);
                ctx.Entry(test).Collection(t => t.questions).Load();
            }


            using (StreamWriter file = new StreamWriter(fileName))
            {
                file.WriteLine("===============================");
                foreach (Question q in test.questions)
                {
                    file.WriteLine(q.ToString());
                    file.WriteLine("===============================");
                }
            }
        }
    }
}
