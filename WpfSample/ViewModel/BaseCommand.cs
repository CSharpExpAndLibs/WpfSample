using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfSample
{
    class BaseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public Action<object> ExecAction { get; private set; } = null;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ExecAction(parameter);
        }

        public BaseCommand(Action<object> callBack)
        {
            ExecAction = callBack;
        }
    }
}
