using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.EquipTests.Desktop.Models
{
    /// <summary>
    /// Провайдер данных 'Test'
    /// </summary>
    public class EquipTestDbData : Services.IEquipTestDataProvider<Test>
    {
        public Test? Add(Test item)
        {
            using(var context = new SparcEquipTestContext())
            {
                context.Add(item);
                return context.SaveChanges() > 0 ? item : null;
            }
        }

        public bool Delete(Test item)
        {
            using (var context = new SparcEquipTestContext()) 
            {
                context.Tests.Remove(item);
                return context.SaveChanges() > 0;
            }
        }

        public IEnumerable<Test> GetAll()
        {
            using (SparcEquipTestContext context = new SparcEquipTestContext()) 
            {
                return context.Tests.ToList();
            }
        }

        public Test? Update(Test item)
        {
            using(var context = new SparcEquipTestContext())
            {
                context.Tests.Update(item);
                return context.SaveChanges() > 0 ? item : null;
            }
        }
    }
}
