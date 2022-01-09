using System;
using System.Windows.Input;

namespace _12_MVVM_concept_with_databinding.Commands
{
	public class MessageCommand : ICommand
	{
        public event EventHandler CanExecuteChanged;
        private Action _Execute;

        public MessageCommand(Action execute)
        {
            _Execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _Execute.Invoke();
        }
    }
}
