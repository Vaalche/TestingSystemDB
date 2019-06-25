using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystemDB;

namespace KursovProektPS
{
    public class UnsavedQuestion
    {
        public string QuestionText { get; set; }

        public string CorrectAnswer { get; set; }

        public string FirstWrongAnswer { get; set; }

        public string SecondWrongAnswer { get; set; }

        public Discipline SelectedDiscipline { get; set; }
    }
}
