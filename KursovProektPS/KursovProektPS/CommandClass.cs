using System;
using System.Windows.Input;

namespace KursovProektPS
{
    public class CommandClass<T> : ICommand where T : class
    {

        private Action<T> _action;
        private Func<bool> _canExecuteEvaluator;
        
        public CommandClass(Action<T> action, Func<bool> canExecuteEvaluator)
        {
            this._action = action;
            this._canExecuteEvaluator = canExecuteEvaluator;
        }

        public CommandClass(Action<T> action)
        : this(action, null)
        {
        }



        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (this._canExecuteEvaluator == null)
            {
                return true;
            }
            else
            {
                bool result = this._canExecuteEvaluator.Invoke();
                return result;
            }
        }

        public void Execute(object parameter)
        {
            var modelInfo = parameter as T;
            _action(modelInfo);
        }
    }
}
