using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystemDB;

namespace KursovProektPS
{
    public class QuestionModel : INotifyPropertyChanged
    {
        private List<Question> questions;
        private  Question currentQuestion;
        private List<Question> testQuestions;
        private string answer1;
        private string answer2;
        private string answer3;
        private int selectedAnswer = 1;

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
                return currentQuestion;
            }

            set
            {
                currentQuestion = value;
                RaisePropertyChanged("CurrentQuestion");
            }
        }

        public string Answer1
        {
            get
            {
                return answer1;
            }

            set
            {
                answer1 = value;
                RaisePropertyChanged("Answer1");
            }
        }

        public string Answer2
        {
            get
            {
                return answer2;
            }

            set
            {
                answer2 = value;
                RaisePropertyChanged("Answer2");
            }
        }

        public string Answer3
        {
            get
            {
                return answer3;
            }

            set
            {
                answer3 = value;
                RaisePropertyChanged("Answer3");
            }
        }

        public int SelectedAnswer
        {
            get
            {
                return selectedAnswer;
            }

            set
            {
                selectedAnswer = value;
            }
        }

        public List<Question> TestQuestions
        {
            get
            {
                return testQuestions;
            }

            set
            {
                testQuestions = value;
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
