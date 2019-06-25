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

        //private string viewName;
        public string ViewTemplateResource { get; set; }

        public BaseVM ViewModel
        {
            get
            {
                return _viewModel;
            }

            private set
            { 
                ViewTemplateResource = value.ResourceName;
                RaisePropertyChanged("ViewTemplateResource");
                _viewModel = value;

                RaisePropertyChanged("ViewModel");
            }
        }

        public ICommand DisplayResultsView
        {
            get
            {
                return new RelayCommand(param => ViewModel = new ResultsVM((int)param));
            }
        }

        public ICommand DisplayTestSetupView
        {
            get
            {
                return new RelayCommand(param => ViewModel = new AuthenticatorVM().Authenticate((LoginModel)param));
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
                return new RelayCommand(param => { if (param != null) ViewModel = new QuestionVM((TestSetupModel)param); });
            }
        }

        public ICommand DisplayAddQuestionView
        {
            get
            {
                return new RelayCommand(param => ViewModel = new AddQuestionVM());
            }
        }
    }
}
