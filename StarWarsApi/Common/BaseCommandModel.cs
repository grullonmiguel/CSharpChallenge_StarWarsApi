using System;
using System.Windows.Input;

namespace StarWarsApi.Common
{
    internal class BaseCommandModel : ICommand
    {

        private readonly Action<object> _action;
        private readonly Predicate<object> _canExecute;

        public BaseCommandModel(Action<object> action, Predicate<object> canExecute) : base()
        {
            _action = action;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

    }
}