using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BaseVM
{
    public class RelayCommand : ICommand 
    { 

        Action<object> _execteMethod;    
        Func<object, bool> _canExecuteMethod;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<object> execteMethod, Func<object, bool> canexecuteMethod)
    {
        _execteMethod = execteMethod;
        _canExecuteMethod = canexecuteMethod;
    }

    public bool CanExecute(object parameter)
    {
        if (_canExecuteMethod != null)
        {
            return _canExecuteMethod(parameter);
        }
        else
        {
            return false;
        }
    }


        public void Execute(object parameter)
    {
        _execteMethod(parameter);
    }
}  

}
