using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using TestingSystemDB;

namespace KursovProektPS
{
    class AddQuestionModel : INotifyPropertyChanged
    {
        private List<Question> questions = new List<Question>();
        private Question question = new Question();
        private string correctAnswer;
        private string wrongAnswer1;
        private string wrongAnswer2;
        private Discipline discipline;
        private List<Discipline> disciplines;

        public Discipline Discipline
        {
            get
            {
                return discipline;
            }

            set
            {
                discipline = value;
                RaisePropertyChanged("Discipline");
            }
        }

        public List<Discipline> Disciplines
        {
            get
            {
                return disciplines;
            }

            set
            {
                disciplines = value;
                RaisePropertyChanged("Disciplines");
            }
        }

        public List<Question> Questions
        {
            get
            {
                return questions;
            }

            set
            {
                questions = value;
                RaisePropertyChanged("Questions");
            }
        }

        public Question CurrentQuestion
        {
            get
            {
                return question;
            }

            set
            {
                question = value;
                RaisePropertyChanged("CurrentQuestion");
            }
        }

        public string CorrectAnswer
        {
            get
            {
                return correctAnswer;
            }

            set
            {
                correctAnswer = value;
                RaisePropertyChanged("correctAnswer");
            }
        }

        public string WrongAnswer1
        {
            get
            {
                return wrongAnswer1;
            }

            set
            {
                wrongAnswer1 = value;
                RaisePropertyChanged("wrongAnswer1");
            }
        }

        public string WrongAnswer2
        {
            get
            {
                return wrongAnswer2;
            }

            set
            {
                wrongAnswer2 = value;
                RaisePropertyChanged("wrongAnswer2");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
