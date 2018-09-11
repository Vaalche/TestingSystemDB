using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KursovProektPS
{
    public class LoginVM : PropertyChangedHandler
    {
        private LoginModel _loginInfo;

        public LoginVM()
        {
            LoginInfo = new LoginModel();
            Login = new LoginCommand(l => AuthenticateUser(l));
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

        public LoginCommand Login
        {
            get;
            set;
        }

        private bool AuthenticateUser(LoginModel loginInfo)
        {
            return true;
        }

    }
}
