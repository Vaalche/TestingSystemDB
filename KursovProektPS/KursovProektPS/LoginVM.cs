using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using KursovProektPS.Views;

namespace KursovProektPS
{
    public class LoginVM : BaseVM
    {
        private BaseVM _viewModel;
        private LoginModel _loginInfo;

        public LoginVM()
        {
            LoginInfo = new LoginModel();
        }

        public LoginModel LoginInfo
        {
            get
            {
                return _loginInfo;
            }

            set
            {
                _loginInfo = value;
                RaisePropertyChanged("LoginInfo");
            }
        }

        public CommandClass<LoginModel> Login
        {
            get;
            set;
        }
    }
}
