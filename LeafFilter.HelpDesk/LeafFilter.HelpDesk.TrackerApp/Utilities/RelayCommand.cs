using LeafFilter.HelpDesk.TrackerApp.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace LeafFilter.HelpDesk.TrackerApp.Utilities
{
    public interface IRelayCommand : ICommand { }

    public class RelayCommand : IRelayCommand
    {
        private Action _TargetExecuteMethod;
        private Func<bool> _TargetCanExecuteMethod;

        public RelayCommand(Action executeMethod)
        {
            _TargetExecuteMethod = executeMethod;
        }

        public RelayCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            _TargetExecuteMethod = executeMethod;
            _TargetCanExecuteMethod = canExecuteMethod;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        #region ICommand Members        
        public event EventHandler CanExecuteChanged = delegate { };

        public bool CanExecute(object parameter)
        {
            if (_TargetCanExecuteMethod != null)
            {
                return _TargetCanExecuteMethod();
            }
            if (_TargetExecuteMethod != null)
            {
                return true;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            if (_TargetExecuteMethod != null)
            {
                _TargetExecuteMethod();
            }
        }
        #endregion     
    }

    public class RelayCommand<T> : IRelayCommand
    {
        private Action<T> _TargetExecuteMethod;
        private Func<T, bool> _TargetCanExecuteMethod;

        public RelayCommand(Action<T> executeMethod)
        {
            _TargetExecuteMethod = executeMethod;
        }

        public RelayCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
        {
            _TargetExecuteMethod = executeMethod;
            _TargetCanExecuteMethod = canExecuteMethod;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        #region ICommand Members
        public event EventHandler CanExecuteChanged = delegate { };

        public bool CanExecute(object parameter)
        {

            if (_TargetCanExecuteMethod != null)
            {
                T tpram = (T)parameter;
                return _TargetCanExecuteMethod(tpram);
            }
            if (_TargetExecuteMethod != null)
            {
                return true;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            if (_TargetExecuteMethod != null)
            {
                _TargetExecuteMethod((T) parameter);
            }
        }
        #endregion
    }
}
