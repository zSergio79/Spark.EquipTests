using Spark.EquipTests.Desktop.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.EquipTests.Desktop.ViewModels
{
    /// <summary>
    /// ViewModel для Test
    /// </summary>
    public class TestViewModel : ViewModelWithEntity<Test>
    {
        #region Bindable Properties
        public DateTime TestDate
        {
            get => Entity.TestDate;
            set
            {
                if (Entity.TestDate != value)
                {
                    Entity.TestDate = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Blockname 
        {
            get=> Entity.Blockname;
            set
            {
                if (Entity.Blockname != value)
                {
                    Entity.Blockname = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? Note 
        {
            get => Entity.Note;
            set
            {
                if(Entity.Note != value)
                {
                    Entity.Note = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region .ctor
        public TestViewModel(Test test) : base(test) 
        {
        }
        #endregion
    }
}
