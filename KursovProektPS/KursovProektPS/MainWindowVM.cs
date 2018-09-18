using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KursovProektPS
{
    public class MainWindowVM : BaseVM
    {
        private BaseVM _viewModel;

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
                return new RelayCommand(action => ViewModel = new ResultsVM());
            }
        }

        public ICommand DisplayTestSetupView
        {
            get
            {
                return new RelayCommand(l => ViewModel = new AuthenticatorVM().Authenticate((LoginModel)l));
            }
        }

        public ICommand DisplayLoginView
        {
            get
            {
                return new RelayCommand(action => ViewModel = new LoginVM());
            }
        }

        public ICommand DisplayQuestionView
        {
            get
            {
                return new RelayCommand(param => ViewModel = new QuestionVM(param));
            }
        }
    }
}
