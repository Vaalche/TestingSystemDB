using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystemDB;

namespace KursovProektPS
{
    class QuestionVM : BaseVM
    {
        public List<Question> questions;
        public QuestionVM(TestSetupModel info)
        {
            GetQuestionsByDiscipline(info.Selection);
        }

        private void GetQuestionsByDiscipline(string selection)
        {
            throw new NotImplementedException();
        }
    }
}
