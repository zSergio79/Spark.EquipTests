using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.EquipTests.Domain.Model
{
    public class Tests
    {
        public int TestId {  get; set; }
        public DateTime TestDate { get; set; }
        public string Blockname { get; set; } = string.Empty;
        public string? Note { get; set; }
    }
}
