using System;
using System.Windows.Input;

namespace KursovProektPS
{
    public class CommandClass<T> : ICommand where T : class
    {
        private Action<T> _action;

        public CommandClass(Action<T> action)
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
            var modelInfo = parameter as T;
            _action(modelInfo);
        }
    }
}
