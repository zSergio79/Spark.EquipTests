using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.EquipTests.Desktop.ViewModels
{
    /// <summary>
    /// Базовый класс для ViewModel 
    /// с сущностью
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ViewModelWithEntity<T> :BaseViewModel
    {
        #region Model
        /// <summary>
        /// Собственно сущность
        /// </summary>
        private readonly T entity;
        public T Entity { get { return entity; } }
        #endregion

        #region .ctor
        public ViewModelWithEntity(T ent)
        {
            this.entity = ent;
        }
        #endregion
    }
}
