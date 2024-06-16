using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Spark.EquipTests.Desktop.ViewModels
{
    /// <summary>
    /// Базовый класс для ViewModel
    /// реализует INotifyPropertyChanged
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string propertyName="")=>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
