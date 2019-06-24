using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using TestingSystemDB;

namespace KursovProektPS
{
    public class QuestionVM : BaseVM
    {
        private QuestionModel questionInfo;
        private static int selectionID;
        private int testScore = 0;
        private bool questionsExtractedFlag = false;
        private int questionCounter = 0;
        private DateTime stopwatch = DateTime.MinValue;
        private DispatcherTimer timer;

        private bool isNextQuestionButtonVisible = true;
        private bool isViewResultsButtonVisible = false;

        public QuestionVM(TestSetupModel info)
        {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            timer.Tick += Timer_Tick;
            timer.Start();
            resourceName = "question";
            questionInfo = new QuestionModel();
            selectionID = info.Selection.id;
        }

        ~QuestionVM()
        {
            timer.Tick -= Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Application.Current.Dispatcher.Invoke(()=>
            {
                stopwatch = stopwatch.AddSeconds(1);
                this.RaisePropertyChanged("TimerValue");
            },DispatcherPriority.ContextIdle);
        }

        public DateTime TimerValue
        {
            get
            {
                return stopwatch;
            }
        }


        public QuestionModel QuestionInfo
        {
            get
            {
                return questionInfo;
            }

            set
            {
                questionInfo = value;
                RaisePropertyChanged("QuestionInfo");
            }
        }

        public ICommand SelectAnswer
        {
            get
            {
                return new RelayCommand(param => QuestionInfo.SelectedAnswer = int.Parse((string)param));
            }
        }

        public ICommand SubmitAnswerCommand
        {
            get
            {
                return new RelayCommand(param => SubmitAnswer());
            }
        }

        public ICommand SelectQuestionCommand
        {
            get
            {
                return new RelayCommand(param => SelectQuestion());
            }
        }

        public bool IsNextQuestionButtonVisible
        {
            get
            {
                return isNextQuestionButtonVisible;
            }

            set
            {
                isNextQuestionButtonVisible = value;
                RaisePropertyChanged("IsNextQuestionButtonVisible");
            }
        }

        public bool IsViewResultsButtonVisible
        {
            get
            {
                return isViewResultsButtonVisible;
            }

            set
            {
                isViewResultsButtonVisible = value;
                RaisePropertyChanged("IsViewResultsButtonVisible");
            }
        }

        public int TestScore
        {
            get
            {
                return testScore;
            }

            set
            {
                testScore = value;
                RaisePropertyChanged("TestScore");
            }
        }

        private void GetQuestionsByDiscipline(int selectionID)
        {
            IRepository<Question> questionRepository = RepositoryFactory.Get<Question>();
            using (var ctx = new TestingSystemModel())
            {
                QuestionInfo.Questions = questionRepository
                .FindBy((question => question.discipline_id == selectionID), ctx)
                .ToList();
            }
            QuestionInfo.TestQuestions = new List<Question>();
        }

        private void SelectQuestion()
        {
            if(!questionsExtractedFlag)
            {
                GetQuestionsByDiscipline(selectionID);
                questionsExtractedFlag = true;
            }
            int position = Randomizer.Next(QuestionInfo.Questions.Count);
            QuestionInfo.CurrentQuestion = QuestionInfo.Questions.ElementAt(position);
            QuestionInfo.Questions.RemoveAt(position);

            List<string> answersToShuffle = new List<string>() { QuestionInfo.CurrentQuestion.correct_answer,
            QuestionInfo.CurrentQuestion.incorrect_answer1, QuestionInfo.CurrentQuestion.incorrect_answer2};

            Randomizer.Shuffle<string>(answersToShuffle);

            QuestionInfo.Answer1 = answersToShuffle.ElementAt(0);
            QuestionInfo.Answer2 = answersToShuffle.ElementAt(1);
            QuestionInfo.Answer3 = answersToShuffle.ElementAt(2);

            QuestionInfo.TestQuestions.Add(QuestionInfo.CurrentQuestion);
            questionCounter++;
        }

        private void SubmitAnswer()
        {
            string answerString;
            switch(QuestionInfo.SelectedAnswer)
            {
                case 1: answerString = QuestionInfo.Answer1;
                    break;

                case 2:
                    answerString = QuestionInfo.Answer2;
                    break;

                case 3:
                    answerString = QuestionInfo.Answer3;
                    break;
                default: answerString = null;
                    break;
            }

            if(answerString != null && answerString.Equals(QuestionInfo.CurrentQuestion.correct_answer))
            {
                TestScore ++;
            }
            if (questionCounter == 5)
            {
                IsNextQuestionButtonVisible = false;
                IsViewResultsButtonVisible = true;
                SubmitTest();
            }
            else
            {
                SelectQuestion();
            }

        }

        private void SubmitTest()
        {
            using (var ctx = new TestingSystemModel())
            {
                IRepository<Test> testRepository = RepositoryFactory.Get<Test>();

                Test newTest = new Test();

                newTest.questions = QuestionInfo.TestQuestions;
                foreach (Question q in newTest.questions)
                {
                    ctx.Questions.Attach(q);
                }
                newTest.user_id = MainWindowVM.CurrentUser.id;
                newTest.score = TestScore;
                testRepository.Add(newTest, ctx);
            }
        }
    }
}
