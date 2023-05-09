using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace calc
{
    public class OperationCommand : ICommand
    {
        private ViewModel _viewModel;

        public OperationCommand (ViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.OperationMethod(parameter as string);
        }
    }
}
