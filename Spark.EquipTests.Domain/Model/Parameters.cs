using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.EquipTests.Domain.Model
{
    public class Parameters
    {
        public int TestId { get;set; }
        public int ParameterId { get; set; }
        public string ParameterName { get; set; } = string.Empty;
        public string RequiredValue { get; set; } = string.Empty;
        public string MeasuredValue { get; set; } = string.Empty;
    }
}
