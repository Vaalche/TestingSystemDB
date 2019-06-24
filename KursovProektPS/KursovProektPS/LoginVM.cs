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
        private LoginModel _loginInfo;

        public LoginVM()
        {
            resourceName = "login";
            LoginInfo = new LoginModel();
        }

        public LoginVM(LoginModel loginInfo)
        {
            LoginInfo = loginInfo;
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
    }
}
