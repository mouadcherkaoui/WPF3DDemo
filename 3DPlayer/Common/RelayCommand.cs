using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Wpf3DPlayer.Common
{
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Action<object> preExecute;
        private Action<object> postExecute;
        private Predicate<object> canExecute;
        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null, Action<object> preExecute = null,
            Action<object> postExecute = null): this(execute, canExecute)
        {
            this.preExecute = preExecute;
            this.postExecute = postExecute;
        }

        private EventHandler canExecuteChanged;
        public event EventHandler CanExecuteChanged
        {
            add { canExecuteChanged += value; }
            remove { canExecuteChanged -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return canExecute?.Invoke(parameter) ?? true ;
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                preExecute?.Invoke(parameter);            
                execute?.Invoke(parameter);
                postExecute?.Invoke(parameter);
            }
        }
    }
    public class RelayCommand<T> : ICommand
    {
        Action<T> execute;
        Action<T> preExecute;
        Action<T> postExecute;
        Predicate<T> canExecute;
        public RelayCommand(Action<T> execute, Predicate<T> canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }
        public RelayCommand(Action<T> execute, Predicate<T> canExecute = null, Action<T> preExecute = null, 
            Action<T> postExecute = null): this(execute, canExecute)
        {
            this.preExecute = preExecute;
            this.postExecute = postExecute;
        }

        private EventHandler canExecuteChanged;
        event EventHandler ICommand.CanExecuteChanged
        {
            add { canExecuteChanged += value; }
            remove { canExecuteChanged -= value; }
        }

        public bool CanExecute(T parameter)
        {
            return canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(T Parameter)
        {
            preExecute?.Invoke(Parameter);
            execute.Invoke(Parameter);
            postExecute?.Invoke(Parameter);
        }

        bool ICommand.CanExecute(object parameter)
        {
            return this.CanExecute((T)parameter);
        }

        void ICommand.Execute(object parameter)
        {
            if (CanExecute((T)parameter))
            {
                this.Execute((T)parameter);
            }
        }
    }
}
