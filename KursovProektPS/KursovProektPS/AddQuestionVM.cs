using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using TestingSystemDB;

namespace KursovProektPS
{
    class AddQuestionVM : BaseVM
    {
        private AddQuestionModel addQuestionInfo;

        public AddQuestionVM()
        {
            resourceName = "add";
            addQuestionInfo = new AddQuestionModel();
            addQuestionInfo.Disciplines = PopulateComboBox();
        }

        public AddQuestionModel AddQuestionInfo
        {
            get
            {
                return addQuestionInfo;
            }

            set
            {
                addQuestionInfo = value;
                RaisePropertyChanged("AddQuestionInfo");
            }
        }

        public ICommand AddQuestionCommand
        {
            get
            {
                return new RelayCommand(param => FillQuestion());
            }
        }

        private List<Discipline> PopulateComboBox()
        {
            IRepository<Discipline> disciplineRepository = RepositoryFactory.Get<Discipline>();

            using (var ctx = new TestingSystemModel())
            {
                return disciplineRepository.FindBy(discipline => true, ctx).ToList();
            }
        }

        private void FillQuestion()
        {
            AddQuestionInfo.AddQuestion();
        }

        public void SaveQuestions()
        {
            IRepository<Question> questionRepository = RepositoryFactory.Get<Question>();
            using (var ctx = new TestingSystemModel())
            {
                foreach (UnsavedQuestion u in AddQuestionInfo.Questions)
                {
                    ctx.Disciplines.Attach(u.SelectedDiscipline);
                    questionRepository.Add(ConvertToQuestion(u), ctx);
                }
            }
        }

        private Question ConvertToQuestion(UnsavedQuestion unsaved)
        {
            Question q = new Question();
            q.question_text = unsaved.QuestionText;
            q.correct_answer = unsaved.CorrectAnswer;
            q.incorrect_answer1 = unsaved.FirstWrongAnswer;
            q.incorrect_answer2 = unsaved.SecondWrongAnswer;
            q.discipline = unsaved.SelectedDiscipline;
            q.is_free_text = false;
            return q;
        }
    }
}
