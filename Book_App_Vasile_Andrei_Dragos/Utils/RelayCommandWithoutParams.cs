using System;
using System.Windows.Input;


namespace Book_App_Vasile_Andrei_Dragos.Utils
{
    public class RelayCommandWithoutParams : ICommand
    {
        private Action executeDelegate = null;
        private Func<bool> canExecuteDelegate = null;
        public event EventHandler CanExecuteChanged;

        public RelayCommandWithoutParams(Action execute)
        {
            executeDelegate = execute;
            canExecuteDelegate = () => { return true; };
        }

        public void NoParameterCommand(Action execute)
        {
            executeDelegate = execute;
            canExecuteDelegate = () => { return true; };
        }
        public void NoParameterCommand(Action execute, Func<bool> canExecute)
        {
            executeDelegate = execute;
            canExecuteDelegate = canExecute;
        }


        public bool CanExecute(object parameter)
        {
            return canExecuteDelegate();
        }

        public void Execute(object parameter)
        {
            if(executeDelegate != null)
            {
                executeDelegate();
            }
        }
    }
}
