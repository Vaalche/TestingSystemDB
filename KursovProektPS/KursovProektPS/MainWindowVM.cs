using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestingSystemDB;

namespace KursovProektPS
{
    public class MainWindowVM : BaseVM
    {
        private BaseVM _viewModel;
        public static User CurrentUser { get; set; }
        public MainWindowVM()
        {
            ViewModel = new LoginVM();
        }

        public BaseVM ViewModel
        {
            get
            {
                return _viewModel;
            }

            private set
            {
                _viewModel = value;
                RaisePropertyChanged("ViewModel");
            }
        }

        public ICommand DisplayResultsView
        {
            get
            {
                return new RelayCommand(param => ViewModel = new ResultsVM((int) param));
            }
        }

        public ICommand DisplayTestSetupView
        {
            get
            {
                return new RelayCommand(param => ViewModel = new Authenticator().Authenticate((LoginModel)param));
            }
        }

        public ICommand DisplayTestSetupViewNoLogin
        {
            get
            {
                return new RelayCommand(param => ViewModel = new TestSetupVM());
            }
        }
        
        public ICommand DisplayStatisticsView
        {
            get
            {
                return new RelayCommand(param => ViewModel = new StatisticsVM());
            }
        }

        public ICommand DisplayLoginView
        {
            get
            {
                return new RelayCommand(param => ViewModel = new LoginVM());
            }
        }

        public ICommand DisplayQuestionView
        {
            get
            {
                return new RelayCommand(param => ViewModel = new QuestionVM((TestSetupModel) param));
            }
        }
    }
}
