using Spark.EquipTests.Desktop.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.EquipTests.Desktop.Models
{
    /// <summary>
    /// Провайдер данных для 'Parameter'
    /// </summary>
    public class ParametersTestDbData : IEquipTestDataProvider<Parameter>
    {
        public Parameter? Add(Parameter item)
        {
            using (var context = new SparcEquipTestContext())
            {
                context.Add(item);
                return context.SaveChanges() > 0 ? item : null;
            }
        }

        public bool Delete(Parameter item)
        {
            using (var context = new SparcEquipTestContext())
            {
                context.Parameters.Remove(item);
                return context.SaveChanges() > 0;
            }
        }

        public IEnumerable<Parameter> GetAll()
        {
            using (SparcEquipTestContext context = new SparcEquipTestContext())
            {
                return context.Parameters.ToList();
            }
        }

        public Parameter? Update(Parameter item)
        {
            using (var context = new SparcEquipTestContext())
            {
                context.Parameters.Update(item);
                return context.SaveChanges() > 0 ? item : null;
            }
        }
    }
}
