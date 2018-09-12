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
                return new CommandClass<ResultsModel>(action => ViewModel = new ResultsVM());
            }
        }


        public ICommand DisplayLoginView
        {
            get
            {
                return new CommandClass<LoginModel>(action => ViewModel = new LoginVM(), () => true);
            }
        }

        private bool AuthenticateUser(LoginModel loginInfo)
        {
            return true;
        }
    }
}
