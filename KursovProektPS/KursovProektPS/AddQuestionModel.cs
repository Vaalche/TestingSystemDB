using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using TestingSystemDB;
using System.Windows;
using System.Windows.Threading;
using System.Collections.ObjectModel;

namespace KursovProektPS
{
    class AddQuestionModel : INotifyPropertyChanged
    {
        private ObservableCollection<UnsavedQuestion> questions = new ObservableCollection<UnsavedQuestion>();
        private List<Discipline> disciplines;
        private string questionText;
        private string correctAnswer;
        private string firstWrongAnswer;
        private string secondWrongAnswer;
        private Discipline selectedDiscipline;

        public string QuestionText
        {
            get
            {
                return questionText;
            }

            set
            {
                questionText = value;
                RaisePropertyChanged("QuestionText");
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
                RaisePropertyChanged("CorrectAnswer");
            }
        }

        public string FirstWrongAnswer
        {
            get
            {
                return firstWrongAnswer;
            }

            set
            {
                firstWrongAnswer = value;
                RaisePropertyChanged("FirstWrongAnswer");
            }
        }

        public string SecondWrongAnswer
        {
            get
            {
                return secondWrongAnswer;
            }

            set
            {
                secondWrongAnswer = value;
                RaisePropertyChanged("SecondWrongAnswer");
            }
        }

        public Discipline SelectedDiscipline
        {
            get
            {
                return selectedDiscipline;
            }

            set
            {
                selectedDiscipline = value;
                RaisePropertyChanged("SelectedDiscipline");
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

        public ObservableCollection<UnsavedQuestion> Questions
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


        public ObservableCollection<UnsavedQuestion> AddQuestion()
        {
            UnsavedQuestion q = new UnsavedQuestion();
            q.QuestionText = QuestionText;
            q.CorrectAnswer = CorrectAnswer;
            q.FirstWrongAnswer = FirstWrongAnswer;
            q.SecondWrongAnswer = SecondWrongAnswer;
            q.SelectedDiscipline = SelectedDiscipline;

            Questions.Add(q);
            return Questions;
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
