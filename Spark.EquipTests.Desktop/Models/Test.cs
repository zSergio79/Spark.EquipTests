using System;
using System.Collections.Generic;

namespace Spark.EquipTests.Desktop.Models;

public partial class Test
{
    public int TestId { get; set; }

    public DateTime TestDate { get; set; }

    public string Blockname { get; set; } = null!;

    public string? Note { get; set; }

    public virtual ICollection<Parameter> Parameters { get; set; } = new List<Parameter>();
}
