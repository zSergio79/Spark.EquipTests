using Spark.EquipTests.Desktop.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.EquipTests.Desktop.ViewModels
{
    /// <summary>
    /// ViewModel для Parameter
    /// </summary>
    public class ParameterViewModel : ViewModelWithEntity<Parameter>
    {
        #region Bindable Properties
        public string ParameterName 
        { 
            get => Entity.ParameterName;
            set
            {
                if (Entity.ParameterName != value) 
                {
                    Entity.ParameterName = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal RequiredValue 
        {
            get => Entity.RequiredValue;
            set
            {
                if (Entity.RequiredValue != value)
                {
                    Entity.RequiredValue = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal MeasuredValue 
        {
            get => Entity.MeasuredValue;
            set
            {
                if (Entity.MeasuredValue != value) 
                {
                    Entity.MeasuredValue = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region .ctor
        public ParameterViewModel(Parameter parameter) : base(parameter)
        {
            
        }
        #endregion
    }
}
