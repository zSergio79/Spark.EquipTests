using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.EquipTests.Desktop.Services
{
    /// <summary>
    /// Интерфейс доступа к данным
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEquipTestDataProvider<T>
    {
        IEnumerable<T> GetAll();
        bool Delete(T item);
        T? Add(T item);
        T? Update(T item);
    }
}
