using System;
using System.Windows.Input;

namespace KursovProektPS
{
    public class LoginCommand : ICommand
    {
        private Action<LoginModel> _action;

        public LoginCommand(Action<LoginModel> action)
        {
            this._action = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var loginInfo = parameter as LoginModel;
            _action(loginInfo);
        }
    }
}
