using System;
using System.ComponentModel;
using System.Security;
using System.Windows.Input;

namespace KursovProektPS
{
    public class LoginModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        private string _errMsg;

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                RaisePropertyChanged("Username");
            }

        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                RaisePropertyChanged("Password");
            }

        }

        public string ErrMsg
        {
            get
            {
                return _errMsg;
            }
            set
            {
                _errMsg = value;
                RaisePropertyChanged("ErrMsg");
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
