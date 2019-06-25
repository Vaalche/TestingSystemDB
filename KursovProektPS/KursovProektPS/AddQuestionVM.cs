using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestingSystemDB;

namespace KursovProektPS
{
    class AddQuestionVM : BaseVM
    {
        private AddQuestionModel addQuestionInfo;
        private List<Question> toSave = new List<Question>();

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

        public ICommand SaveQuestionCommand
        {
            get
            {
                return new RelayCommand(param => SaveQuestions());
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
            Question question = new Question();

            if(AddQuestionInfo.CurrentQuestion.question_text != string.Empty)
            {
                question.question_text = AddQuestionInfo.CurrentQuestion.question_text;
            }

            if (AddQuestionInfo.CurrentQuestion.correct_answer != string.Empty)
            {
                question.correct_answer = AddQuestionInfo.CurrentQuestion.correct_answer;
            }

            if (AddQuestionInfo.CurrentQuestion.incorrect_answer1 != string.Empty)
            {
                question.incorrect_answer1 = AddQuestionInfo.CurrentQuestion.incorrect_answer1;
            }

            if (AddQuestionInfo.CurrentQuestion.incorrect_answer2 != string.Empty)
            {
                question.incorrect_answer2 = AddQuestionInfo.CurrentQuestion.incorrect_answer2;
            }

            if (AddQuestionInfo.CurrentQuestion.discipline != null)
            {
                question.discipline = AddQuestionInfo.CurrentQuestion.discipline;
            }

            toSave.Add(question);
        }

        private void SaveQuestions()
        {
            foreach(Question q in toSave)
            {

            }
        }
    }
}
