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
    public class LoginVM : PropertyChangedHandler
    {
        private LoginModel _loginInfo;

        public LoginVM()
        {
            LoginInfo = new LoginModel();
            Login = new CommandClass<LoginModel>(l => AuthenticateUser(l));

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

        private bool AuthenticateUser(LoginModel loginInfo)
        {
            TestSetup ts = new TestSetup();
            return true;
        }
    }
}
