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

        private string _errorMessage;

        public LoginVM()
        {
            resourceName = "login";
            LoginInfo = new LoginModel();
        }

        public LoginVM(LoginModel loginInfo)
        {
            LoginInfo = loginInfo;
        }

        public LoginVM(LoginModel loginInfo, string errMsg)
        {
            resourceName = "login";
            LoginInfo = loginInfo;
            loginInfo.ErrMsg = errMsg;
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

        //public string ErrorMessage
        //{
        //    get
        //    {
        //        return _errorMessage;
        //    }

        //    set
        //    {
        //        _errorMessage = value;
        //        RaisePropertyChanged("ErrorMessageLogin");
        //    }
        //}
    }
}
