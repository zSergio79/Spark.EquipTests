using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Spark.EquipTests.Desktop.Infrastructure
{
    /// <summary>
    /// Реализация ICommand
    /// </summary>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// Команда
        /// </summary>
        private Action<object?> execute;
        /// <summary>
        /// Возможность выполнения команды
        /// </summary>
        private Func<object?, bool> canExecute;

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object?> execute, Func<object?, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            this.execute(parameter);
        }
    }
}
