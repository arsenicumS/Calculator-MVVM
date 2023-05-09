using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace calc
{
    public class NamberCommand : ICommand
    {
        private ViewModel _viewModel;

       public NamberCommand(ViewModel viewModel) 
        {
            this._viewModel = viewModel;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.NamberMethod(parameter as string);
        }
    }
}
